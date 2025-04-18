using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Options")]
    public Slider volumenFX;
    public Slider volumenMaster;
    public Toggle mute, personaje1, personaje2, personaje3;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound; //disparo;
    private float lastVolume;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionPanel;
    public GameObject creditosPanel;

    private void Awake(){  // Los sliders estan a la espera de la interaccion
        volumenFX.onValueChanged.AddListener(CambiarVolumenFX);
        volumenMaster.onValueChanged.AddListener(CambiarVolumenMaster);
        if(Player.personajeActivo == 1) {
            personaje1.isOn = true;
            personaje2.isOn = false;
            personaje3.isOn = false;
        } else if (Player.personajeActivo == 2) {
            personaje2.isOn = true;
            personaje1.isOn = false;
            personaje3.isOn = false;
        } else if (Player.personajeActivo == 3) {
            personaje3.isOn = true;
            personaje2.isOn = false;
            personaje1.isOn = false;
        }
    }

    public void JugarJuego(string juego){  // Cambiar a escena del juego
        if(juego=="main"){ // Si se reinicia el juego
            Time.timeScale = 1;
            //Player.estaVivo = true;
            //GameObject.Find("/Canvas/btnVolar").SetActive(true);
            //VidasPlayer.vidasINI = 5;
        }
        //PlaySoundButton();
        SceneManager.LoadScene(juego);
    }

    public void AbrirMainMenu(string escena){
        //Debug.Log(escena);
        //PlaySoundButton();
        SceneManager.LoadScene(escena);
    }

    public void SalirJuego(){
        PlaySoundButton();
        Application.Quit();
    }

    public void SetMute(){
        if(mute.isOn){
            mixer.GetFloat("VolMaster", out lastVolume);
            mixer.SetFloat("VolMaster", -80);
        } else {
            mixer.SetFloat("VolMaster", lastVolume);
        }
    }

    public void SetPersonaje(){
        PlaySoundButton();
        if(personaje1.isOn){
            Player.personajeActivo = 1;
            //Debug.Log("perosnaje1");
            //GameObject.Find("main/pajaroRojo").SetActive(true);
        } 
        if(personaje2.isOn){
            //Debug.Log("perosnaje2");
            //GameObject.Find("main/personaje2").SetActive(true);
            Player.personajeActivo = 2;
        } 
        if(personaje3.isOn){
            //GameObject.Find("main/pajaroRojo").SetActive(true);
            Player.personajeActivo = 3;
        } 
    }

    public void AbrirPanel(GameObject panel){
        Time.timeScale = 0;
        mainPanel.SetActive(false);
        optionPanel.SetActive(false);
        creditosPanel.SetActive(false);
        panel.SetActive(true);
        PlaySoundButton();
    }

    public void CerrarPanel(){
        Time.timeScale = 1;
        mainPanel.SetActive(false);
        PlaySoundButton();
    }

    // Aqui se cambia el valor de los sliders y por lo tanto el volumen
    public void CambiarVolumenMaster(float v){
        mixer.SetFloat("VolMaster",v);
    }
    public void CambiarVolumenFX(float v){
        mixer.SetFloat("VolFX",v);
    }

    // Activar sonido de los click en los botones
    public void PlaySoundButton(){
        fxSource.PlayOneShot(clickSound);
    }

    /*public void PlaySoundDisparo(){
        fxSource.PlayOneShot(disparo);
    }*/

}
