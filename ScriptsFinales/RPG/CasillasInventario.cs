using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasillasInventario : MonoBehaviour
{   
    public static GameObject gemaRoja, gemaAzul, gemaVerde, mochila, carta, mapa, pergamino, libro, cristal, diamante; 
    
    void Start(){
        gemaRoja.SetActive(false);
        gemaAzul.SetActive(false); 
        gemaVerde.SetActive(false);
        mochila.SetActive(false);
        carta.SetActive(false);
        mapa.SetActive(false);
        pergamino.SetActive(false);
        libro.SetActive(false);
        cristal.SetActive(false);
        diamante.SetActive(false);
    }

    public static void MostrarInfo(string info){

        if(info == "gemaRoja"){
            gemaRoja.SetActive(true);
        }
        if(info == "gemaAzul"){
            gemaAzul.SetActive(true);
        }
        if(info == "gemaVerde"){
            gemaVerde.SetActive(true);
        }
        if(info == "mochila"){
            mochila.SetActive(true);
        }
        if(info == "carta"){
            carta.SetActive(true);
        }
        if(info == "mapa"){
            mapa.SetActive(true);
        }
        if(info == "pergamino"){
            pergamino.SetActive(true);
        }
        if(info == "libro"){
            libro.SetActive(true);
        }
        if(info == "cristal"){
            cristal.SetActive(true);
        }
        if(info == "diamante"){
            diamante.SetActive(true);
        }
    }
    
    
}
