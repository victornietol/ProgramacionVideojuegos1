using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidasPlayer : MonoBehaviour
{
    public Image vidaPlayer;
    private float anchoVidasPlayer;
    public static int vida;
    private bool haMuerto;
    public GameObject gameOver;
    public const int vidasINI = 7; // Veces que se recibe daño antes de morir
    public static int puedePerderVida = 1;

    // Ajustes iniciales
    void Start(){
        anchoVidasPlayer = vidaPlayer.GetComponent<RectTransform>().sizeDelta.x;
        haMuerto = false;
        vida = vidasINI;
        gameOver.SetActive(false);
    }

    // Daño que obtiene el player
    public void TomarDanio(int danio){
        if(vida>0 && puedePerderVida==1){
            puedePerderVida = 0;
            vida -= danio;
            DibujaVida(vida);
        }
        if(vida<=0 && !haMuerto){
            haMuerto = true;
            StartCoroutine(EjecutaMuerte());
        }
    }

    // Dibujar vida
    public void DibujaVida(int vida){
        /*
        if(vida<=vidasINI){ // Si la vida es menor al limite de vida
            RectTransform transformaImage = vidaPlayer.GetComponent<RectTransform>();
            transformaImage.sizeDelta = new Vector2(anchoVidasPlayer*(float)vida / (float)vidasINI, transformaImage.sizeDelta.y);
        }*/
        RectTransform transformaImage = vidaPlayer.GetComponent<RectTransform>();
            transformaImage.sizeDelta = new Vector2(anchoVidasPlayer*(float)vida / (float)vidasINI, transformaImage.sizeDelta.y);
    }

    // Mostrar muerte
    IEnumerator EjecutaMuerte(){
        yield return new WaitForSeconds(0.5f);
        gameOver.SetActive(true);
    }

}