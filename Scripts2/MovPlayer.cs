using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{
    private Vector2 dirMov;
    public float velMov;
    public Rigidbody2D rb;
    public Animator anim;

    private string capaIdle = "idle";
    private string capaCaminar = "Caminar";
    private bool PlayerMoviendose = false;
    private float ultimoMovX, ultimoMovY;

    public static int dirAtaque = 0;  // 1- Front, 2- Back, 3- Left, 4- Right (correspondencia c/ataque)
    
    void FixedUpdate(){
        Movimiento();
        //Animacionesplayer();
        if(CCC.atacando==false && CAD.disparando==false){
            Animacionesplayer();
        }
    }

    private void Movimiento(){
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        dirMov = new Vector2(movX,movY).normalized;
        rb.velocity = new Vector2(dirMov.x*velMov, dirMov.y*velMov);

        if(movX==1 && movY==1){    // diagonales
            dirAtaque = 5;
        } else if(movX==-1 && movY==1){
            dirAtaque = 6;
        } else if(movX==1 && movY==-1){
            dirAtaque = 7;
        } else if(movX==-1 && movY==-1){
            dirAtaque = 8;
        } else if(movX == 0 && movY==-1){ // una sola direccion
            dirAtaque = 1;
        } else if (movX == 0 && movY==1){
            dirAtaque = 2;
        } else if (movX == -1 && movY==0){
            dirAtaque = 3;
        } else if (movX == 1 && movY==0){
            dirAtaque = 4;
        }   

        // Animacion del player segun la entrada (si esta caminando o quieto)
        if(movX == 0 && movY == 0){ // idle
            PlayerMoviendose = false;
        } else {  // caminar
            PlayerMoviendose = true;
            ultimoMovX = movX;
            ultimoMovY = movY;
        }
        ActualizaCapa();

    }

    private void Animacionesplayer(){
        anim.SetFloat("movX",ultimoMovX);
        anim.SetFloat("movY",ultimoMovY);
    }

    private void ActualizaCapa(){
        if(CCC.atacando==false && CAD.disparando==false){
            if(PlayerMoviendose){
                activaCapa(capaCaminar);
                //Debug.Log("Caminando");
            } else {
                activaCapa(capaIdle);
                //Debug.Log("Idle");
            }
        } else {
            activaCapa("Ataque");
        }
        
    }

    // Dependiendo del valor se activara una capa
    private void activaCapa(string nombre){
        for(int i=0; i<anim.layerCount; i++){
            anim.SetLayerWeight(i,0); // Ambos layes con peso en 0
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre),1); // Se cambia el peso a 1 dependiendo de nombre
    }
}
