using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAD : MonoBehaviour
{
    [SerializeField] private GameObject proyectil; //se puede usar la circunferencia que hace al inicio del video o se puede bajar algo de internet
    public float tiempoEntreAtaques;
    public float tiempoSigAtaque;
    public Transform puntoEmision;
    private Animator anim;
    public static int dirDisparo = 0;
    public static bool disparando = false; 
    public static bool disminuirMana = false;

    
    void Start(){
        anim = GetComponent<Animator>();
    }

    void Update(){
        if (tiempoSigAtaque<0.05f && tiempoEntreAtaques>0){
            disparando = false;
            ManaPlayer.puedePerderMana = 1;
        }
        if (tiempoSigAtaque > 0){
            tiempoSigAtaque -= Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire2") && tiempoSigAtaque<=0 && ManaPlayer.mana>0){ // lo unico que cambia aca es que preguntamos por el boton derecho del mouse, o un boton secundario
            //Debug.Log("DISPAROOOOO");
            //ManaPlayer.DisminuirMana(1); // restando mana de la barra
            disminuirMana = true;  // quitar mana 
            disparando = true;
            activaCapa("Ataque");
            Dispara();  // se usa un metodo dispara en lugar de golpe
            tiempoSigAtaque = tiempoEntreAtaques; 
        }
        //disminuirMana = false; // restablecer el estado despues del disparo

    }

    private void Dispara()  
    {
        if (MovPlayer.dirAtaque == 1){
            anim.SetTrigger("disparaFront");
        } else if (MovPlayer.dirAtaque == 2){
            anim.SetTrigger("disparaBack");
        } else if (MovPlayer.dirAtaque == 3){
            anim.SetTrigger("disparaIzquierda");
        } else if (MovPlayer.dirAtaque == 4){
            anim.SetTrigger("disparaDerecha");
        } //muestra animaciones en el 17:50 
        else {
            Debug.Log("DISPAROOOOOOO"+MovPlayer.dirAtaque);
        }
    }

    private void EmiteProyectil(){
        dirDisparo = MovPlayer.dirAtaque; //se graba la direccion de ataque en la que se hizo el disparo y despues se instancia el proyectil
        Debug.Log("DISPAROOO"+dirDisparo);
        Instantiate(proyectil, puntoEmision.position, transform.rotation); // se genera un bolita desde la posicion de punto de emision, pero no se mueve,
        // lo que hara que se mueva es el de dispara proyectil
    }

    // lo mismo que las dos anteriores
    private void activaCapa(string nombre){
        for (int i = 0; i < anim.layerCount; i++){
            anim.SetLayerWeight(i, 0);
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
    }
    

}