using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    private bool muestraInventario;
    public GameObject goInventario;
    [SerializeField] private string[] valoresInventario;
    private int numGemasVerdes, numGemasAzules, numGemasRojas, numDiamantes, numCristales;
    Button boton;
    public Sprite mochila, carta, mapa, pergamino, libro, gemaRoja, gemaVerde, gemaAzul, cristal, diamante, contenedor, peto, casco, llave, casillas;
    public static bool existeLlave = false;
    Image imagen;

    void Start() {
        muestraInventario = false;
        BorraArreglo();
        numGemasAzules = 0;
        numGemasRojas = 0;
        numGemasVerdes = 0;
        numCristales = 0;
        numDiamantes = 0;
        existeLlave = false;
    }

    public void StatusInventario() {
        GameObject.Find("CanvasMenu").GetComponent<MainMenu>().PlaySoundButton();
        if (muestraInventario) {
            muestraInventario = false;
            goInventario.SetActive(false);
            Time.timeScale = 1;  // Sirve para detener lo que pasa en el juego mientras se esta en el inventario
        } else {
            muestraInventario = true;
            goInventario.SetActive(true);
            GameObject.Find("/Canvas/fondoInventario/infoObjetos").SetActive(false);
            Time.timeScale = 0;
        }
    }
    
    public void EscribeEnArreglo() {
        if (VerificaEnArreglo() == -1) { // No esta en el inventario
            for (int i = 0; i < valoresInventario.Length; i++) {
                if (valoresInventario[i] == "") { // Lo colaca en la primera posicion vacia que encuentre
                    valoresInventario[i] = ColeccionablesPlayer.objAColeccionar;
                    DibujaElementos(i);
                    break;
                }
            }
        } else { // Si ya esta en el inventario, ubica su posicion y suma uno al elemento
            DibujaElementos(VerificaEnArreglo());
        }
    }

    private int VerificaEnArreglo() {
        int pos = -1;
        for (int i = 0;i < valoresInventario.Length;i++) {
            if (valoresInventario[i] == ColeccionablesPlayer.objAColeccionar) {
                pos  = i; 
                break;
            }
        }
        return pos;
    }

    public void DibujaElementos(int pos) {
        StatusInventario();
        boton = GameObject.Find("elemento ("+pos+")").GetComponent<Button>();
        switch (ColeccionablesPlayer.objAColeccionar){
            case "mochila":
                contenedor = mochila;
                break;
            case "carta":
                contenedor = carta;
                break;
            case "mapa":
                contenedor = mapa;
                break;
            case "pergamino":
                contenedor = pergamino;
                break;
            case "libro":
                contenedor = libro;
                break;
            case "gemaRoja":
                contenedor = gemaRoja;
                numGemasRojas++;
                boton.GetComponentInChildren<Text>().text = "x" + numGemasRojas.ToString();
                break;
            case "gemaVerde":
                contenedor = gemaVerde;
                numGemasVerdes++;
                boton.GetComponentInChildren<Text>().text = "x" + numGemasVerdes.ToString();
                break;
            case "gemaAzul":
                contenedor = gemaAzul;
                numGemasAzules++;
                boton.GetComponentInChildren<Text>().text = "x" + numGemasAzules.ToString();
                break;
            case "cristal":
                contenedor = cristal;
                numCristales++;
                boton.GetComponentInChildren<Text>().text = "x" + numCristales.ToString();
                break;
            case "diamante":
                contenedor = diamante;
                numDiamantes++;
                boton.GetComponentInChildren<Text>().text = "x" + numDiamantes.ToString();
                break;
            case "llave":
                contenedor = llave;
                existeLlave = true;
                break;
        }
        boton.GetComponent<Image>().sprite = contenedor;
    }

    
    public void ActivarItem(GameObject casilla){
        GameObject.Find("CanvasMenu").GetComponent<MainMenu>().PlaySoundButton();

        // Cerrando todas las informaciones disponibles
        GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoGemaRoja").SetActive(false);
        GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoMochila").SetActive(false);
        GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoCarta").SetActive(false);
        GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoMapa").SetActive(false);
        GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoPergamino").SetActive(false);
        GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoLibro").SetActive(false);
        GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoGemaAzul").SetActive(false);
        GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoGemaVerde").SetActive(false);
        GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoCristal").SetActive(false);
        GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoDiamante").SetActive(false);
        GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoLlave").SetActive(false);
        
        // Obteniendo el objeto de la casilla
        imagen=casilla.GetComponent<Image>();

        // Activando fondo de la descripcion para poder mostrar info
        if(imagen.sprite!=casillas){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos").SetActive(true);
        } else {  // si la casilla esta vacia no muestra nada
            GameObject.Find("/Canvas/fondoInventario/infoObjetos").SetActive(false);
        }

        // Activando descripcion
        if(imagen.sprite==gemaRoja){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoGemaRoja").SetActive(true);
        }
        if(imagen.sprite==mochila){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoMochila").SetActive(true);
        }
        if(imagen.sprite==carta){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoCarta").SetActive(true);
        }
        if(imagen.sprite==mapa){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoMapa").SetActive(true);
        }
        if(imagen.sprite==pergamino){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoPergamino").SetActive(true);
        }
        if(imagen.sprite==libro){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoLibro").SetActive(true);
        }
        if(imagen.sprite==gemaAzul){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoGemaAzul").SetActive(true);
        }
        if(imagen.sprite==gemaVerde){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoGemaVerde").SetActive(true);
        }
        if(imagen.sprite==cristal){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoCristal").SetActive(true);
        }
        if(imagen.sprite==diamante){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoDiamante").SetActive(true);
        }
        if(imagen.sprite==llave){
            GameObject.Find("/Canvas/fondoInventario/infoObjetos/infoLlave").SetActive(true);
        }
    }

    public void CerrarInfoInventario(){
        GameObject.Find("CanvasMenu").GetComponent<MainMenu>().PlaySoundButton();
        GameObject.Find("/Canvas/fondoInventario/infoObjetos").SetActive(false);
    }

    private void BorraArreglo(){
        for (int i = 0; i < valoresInventario.Length; i++) {
            valoresInventario[i] = "";
        }
    }

    public void DescripcionArmadura(GameObject boton){
        GameObject.Find("CanvasMenu").GetComponent<MainMenu>().PlaySoundButton();
        GameObject.Find("/Canvas/fondoPlayer/btnCasco/fondoDesc").SetActive(false);
        GameObject.Find("/Canvas/fondoPlayer/btnArmadura/fondoDesc").SetActive(false);

        if(boton==GameObject.Find("/Canvas/fondoPlayer/btnArmadura")){
            GameObject.Find("/Canvas/fondoPlayer/btnArmadura/fondoDesc").SetActive(true);
            if(ColeccionablesPlayer.existeArmadura){
                GameObject.Find("/Canvas/fondoPlayer/btnArmadura/fondoDesc/descNoActiva").SetActive(false);
                GameObject.Find("/Canvas/fondoPlayer/btnArmadura/fondoDesc/descActiva").SetActive(true);
            } else {
                GameObject.Find("/Canvas/fondoPlayer/btnArmadura/fondoDesc/descNoActiva").SetActive(true);
                GameObject.Find("/Canvas/fondoPlayer/btnArmadura/fondoDesc/descActiva").SetActive(false);
            }
        }
        if(boton==GameObject.Find("/Canvas/fondoPlayer/btnCasco")){
            GameObject.Find("/Canvas/fondoPlayer/btnCasco/fondoDesc").SetActive(true);
            if(ColeccionablesPlayer.existeCasco){
                GameObject.Find("/Canvas/fondoPlayer/btnCasco/fondoDesc/descNoActiva").SetActive(false);
                GameObject.Find("/Canvas/fondoPlayer/btnCasco/fondoDesc/descActiva").SetActive(true);
            } else {
                GameObject.Find("/Canvas/fondoPlayer/btnCasco/fondoDesc/descNoActiva").SetActive(true);
                GameObject.Find("/Canvas/fondoPlayer/btnCasco/fondoDesc/descActiva").SetActive(false);
            }
        }
    }

    public void CerrarDescripcionArmadura(){
        GameObject.Find("CanvasMenu").GetComponent<MainMenu>().PlaySoundButton();
        GameObject.Find("/Canvas/fondoPlayer/btnCasco/fondoDesc").SetActive(false);
        GameObject.Find("/Canvas/fondoPlayer/btnArmadura/fondoDesc").SetActive(false);
    }

    // Cerrar mensaje de portal Mansion
    public void CerraAdvertenciaMansion(){
        GameObject.Find("CanvasMenu").GetComponent<MainMenu>().PlaySoundButton();
        GameObject.Find("/Canvas/fondoPlayer/advertenciaMansion").SetActive(false);
    }
    
}
