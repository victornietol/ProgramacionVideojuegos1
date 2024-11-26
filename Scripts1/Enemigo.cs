using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public static int vidaEnemigo = 1;
    private float frecAtaque = 2.5f, tiempoSigAtaque = 0, iniciaConteo;

    public Transform personaje;
    private NavMeshAgent agente;
    public Transform[] puntosRuta;
    private int indiceRuta = 0;
    private bool playerEnRango = false;
    [SerializeField] private float distanciaDeteccionPlayer; // Ajusta la distancia a la que se detecta al player
    private SpriteRenderer spriteEnemigo;
    private Transform mirarHacia;

    private void Awake(){
        agente = GetComponent<NavMeshAgent>();
        spriteEnemigo = GetComponent<SpriteRenderer>();
    }

    void Start(){
        vidaEnemigo = 1;
        agente.updateRotation = false;
        agente.updateUpAxis = false;
    }

    void Update(){
        this.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        float distancia = Vector3.Distance(personaje.position, this.transform.position);

        if(this.transform.position == puntosRuta[indiceRuta].position){ //Animacion programada con puntos de ruta
            if(indiceRuta<(puntosRuta.Length -1)){
                indiceRuta++;
            } else if(indiceRuta == (puntosRuta.Length -1)) {
                indiceRuta = 0;
            }
        }
        if(distancia<distanciaDeteccionPlayer){
            playerEnRango = true;
        } else {
            playerEnRango = false;
        }

        if(tiempoSigAtaque>0){  // Cada cuando va a atacar el enemigo
            tiempoSigAtaque = frecAtaque+iniciaConteo - Time.time;
        } else { // EL player sigue perdiendo vida si toca al enemigo
            tiempoSigAtaque = 0;
            VidasPlayer.puedePerderVida = 1;
            SigueAlPlayer(playerEnRango);
            RotarEnemigo();
        }
    }

    private void SigueAlPlayer(bool playerEnRango){
        if(playerEnRango){ // Seguir al player
            agente.SetDestination(personaje.position);
            mirarHacia =personaje;
        } else {       // Enemigo sigue su ruta
            agente.SetDestination(puntosRuta[indiceRuta].position);
            mirarHacia = puntosRuta[indiceRuta];
        }
    }

    private void RotarEnemigo(){
        if(this.transform.position.x>mirarHacia.position.x){
            spriteEnemigo.flipX = true;
            //Debug.Log("FlipX");
        } else {
            spriteEnemigo.flipX = false;
            //Debug.Log("Sin FlipX");
        }
    }

    private void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag == "Player"){
            tiempoSigAtaque = frecAtaque;
            iniciaConteo = Time.time;
            obj.transform.GetComponentInChildren<VidasPlayer>().TomarDanio(1);
        }
    }

    public void TomarDanio(int danio){
        vidaEnemigo -= danio;
        if(vidaEnemigo<=0){
            Destroy(gameObject);
        }
    }
}
