using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCC : MonoBehaviour
{
    public Transform controladorGolpe;
    public float radioGolpe;
    public int danioGolpe;
    public float tiempoEntreAtaques;
    public float tiempoSigAtaque;
    private Animator anim;

    public static bool atacando; // variables estaticas que se tendran para atacando y disparando y se referencia en los condicionales en el MovPlayer2

    // acceso al animator controler
    private void Start(){
        anim = GetComponent<Animator>();
    }

    private void Update(){
        if(tiempoSigAtaque<0.05f && tiempoEntreAtaques>0){ // pregunta que si el tiempo entre ataques esta entre 0 y 0.05, practicamente se acaba el tiempo, lo pondra en false
            atacando = false;
        }
        if(tiempoSigAtaque>0){ // si el tiempo es positivo seguira decrementando el tiempo hasta que llegue a cero y pasa al sig if
            tiempoSigAtaque -= Time.deltaTime;
        }
        if(Input.GetButtonDown("Fire1") && tiempoSigAtaque<=0){ //si es asi junto con el boton de disparo y el tiempo en cero se activara el atacando
            //Debug.Log("GOLPEEEEEEEEE");
            atacando = true;
            activaCapa("Ataque");
            Golpe();
            tiempoSigAtaque = tiempoEntreAtaques; // esto para regresarlo a la frecuencia en la que lo tenemos declarada desde el inicio desde unity
        }
    }

    private void Golpe(){ // el metodo golpe pregunta cual es la direccion de ataque y dependiendo del movPlayer pues hara los ataques en esa direccion 
        if(MovPlayer.dirAtaque == 1){
            anim.SetTrigger("ataqueFront");
        } else if (MovPlayer.dirAtaque == 2){
            anim.SetTrigger("ataqueBack");
        } else if (MovPlayer.dirAtaque == 3){
            anim.SetTrigger("ataqueIzquierda");
        } else if (MovPlayer.dirAtaque == 4){
            anim.SetTrigger("ataqueDerecha");
        }
    }

    private void VerificaGolpe(){ //verifica golpe menciona en el 13:25 por que no esta referenciado, es basicamente por que en la animacion la referenciamos en los eventos 
        Collider2D[] objs = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe); // que verifica justo lo que se manda en el frame de cierta posicion 
        foreach(Collider2D colisionador in objs){ // y verifica si golpeo
            if (colisionador.CompareTag("enemigo")){
                colisionador.transform.GetComponent<Enemigo>().TomarDanio(danioGolpe); // y le marca al enemigo el danio que se realizo 
            } 
        }
    }

    private void OnDrawGizmos(){  // ------- TAL VEZ NO LO OCUPE
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

    private void activaCapa(string nombre){
        for (int i = 0; i < anim.layerCount; i++){
            anim.SetLayerWeight(i, 0);
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
    }
    // ataque a distancia sera un copia y pega de este casi casi pero con una que otra cosa diferente 

}
