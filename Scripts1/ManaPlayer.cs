using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaPlayer : MonoBehaviour
{
    public Image manaPlayer;
    private float anchoManasPlayer;
    public static int mana;
    //private bool haMuerto;
    public const int manasINI = 7; // Veces que se recibe daño antes de morir
    public static int puedePerderMana = 1;
    //private static bool disparo;

    // Ajustes iniciales
    void Start(){
        //disparo = CAD.disparando;
        anchoManasPlayer = manaPlayer.GetComponent<RectTransform>().sizeDelta.x;
        mana = manasINI;
        //haMuerto = false;
        //gameOver.SetActive(false);
    }

    void Update() {
        //Debug.Log("CAAAAD"+CAD.disminuirMana);
        if(CAD.disparando){
            DisminuyendoMana(1);
        }
    }

    // Daño que obtiene el player
    public void DisminuyendoMana(int disminuir){
        if(mana>0 && puedePerderMana==1){
            puedePerderMana = 0;
            mana -= disminuir;
            DibujaMana(mana);
        }/*
        if(mana<=0){
            haMuerto = true;
            StartCoroutine(EjecutaMuerte());
        }*/
    }

    // Dibujar mana
    public void DibujaMana(int mana){
        RectTransform transformaImage = manaPlayer.GetComponent<RectTransform>();
            transformaImage.sizeDelta = new Vector2(anchoManasPlayer*(float)mana / (float)manasINI, transformaImage.sizeDelta.y);
    }
}
