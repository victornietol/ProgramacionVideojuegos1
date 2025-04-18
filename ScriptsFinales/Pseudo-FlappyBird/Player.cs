using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instancia;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator anim;
    public bool yaVolo, estaVivo;
    public float valorOffset = 0;
    private float velocidad = 3.0f, fuerzarebote = 4.0f;
    private Button btnVolar;

    public static int score, record;  // --------
    public AudioSource reproductorPts, reproductorMuerte, reproductorVuela;
    public AudioClip sndPts, sndMuerte, sndVuela;
    public Text txtScore, txtPuntuacionFinal, txtRecord;
    public GameObject gameOver, btnVolarApagar, personaje1, personaje2, personaje3;

    public static int personajeActivo=1;
    //private int record = 0;
    
    void Awake() {
        if(personajeActivo==1){
            personaje1.SetActive(true);
            personaje2.SetActive(false);
            personaje3.SetActive(false);
        }
        if(personajeActivo==2){
            personaje1.SetActive(false);
            personaje2.SetActive(true);
            personaje3.SetActive(false);
        }
        if(personajeActivo==3){
            personaje1.SetActive(false);
            personaje2.SetActive(false);
            personaje3.SetActive(true);
        }

        score = 0;
        //record = 0; // ----------------------
        if(instancia == null){
            instancia = this;
        }
        estaVivo = true;
        btnVolar = GameObject.FindGameObjectWithTag("btnVolar").GetComponent<Button>();
        btnVolar.onClick.AddListener( ()=> VuelaPajaro() );
        AsignaPosXCamara();

        
    }

    void FixedUpdate() {
        if(estaVivo){
            Vector3 temp = transform.position;
            temp.x += velocidad * Time.deltaTime;
            transform.position = temp;

            if(yaVolo){
                yaVolo = false;
                rb2d.velocity = new Vector2(0,fuerzarebote);
                anim.SetTrigger("volando");
                reproductorVuela.clip = sndVuela;
                reproductorVuela.Play();
            }

            if(rb2d.velocity.y >= 0){
                transform.rotation = Quaternion.Euler(0,0,0);
            } else {
                float angulo = 0;
                angulo = Mathf.Lerp(0,-90,-rb2d.velocity.y / 10);  // Para cambiar el giro de la animacion al caer el personaje se cambia el valor "21"
                transform.rotation = Quaternion.Euler(0,0,angulo);
            }
        }

    }

    private void AsignaPosXCamara() {
        CamaraScript.offsetX = Camera.main.transform.position.x - transform.position.x - valorOffset;
    }

    public float ObtenPosX() {
        return transform.position.x;
    }

    private void VuelaPajaro() {
        yaVolo = true;
    }

    private void OnTriggerEnter2D(Collider2D obj) {  // anotacion de puntos
        if(obj.tag == "tuboGrupo") {
            score++;
            txtScore.text = score.ToString();
            txtPuntuacionFinal.text = score.ToString();  // Marcador final pantalla Game Over
            reproductorPts.clip = sndPts;
            reproductorPts.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D obj) {
        if(obj.gameObject.tag=="piso" || obj.gameObject.tag=="tubo") {
            //Debug.Log("PISO1");
            if(estaVivo) {
                //Debug.Log("PISO2");
                estaVivo = false;
                anim.SetTrigger("muere");
                reproductorMuerte.clip = sndMuerte;
                reproductorMuerte.Play();
                StartCoroutine(EjecutaMuerte());

                if(record<=score){ // Actualizacion de puntuacion mas alta
                    //Debug.Log("score: "+score+" | record: "+record);
                    record = score;
                    txtRecord.text = record.ToString();
                } else {
                    //Debug.Log("score2: "+score+" | record2: "+record);
                    txtRecord.text = record.ToString();
                }

            }
        }
    }

    IEnumerator EjecutaMuerte(){
        yield return new WaitForSeconds(0.5f);
        txtScore.text="";
        gameOver.SetActive(true);
        btnVolarApagar.SetActive(false);
        //estaVivo = true; // -------------------------------
    }
    
}
