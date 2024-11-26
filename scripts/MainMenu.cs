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
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxSource;
    public AudioClip clickSound, disparo;
    private float lastVolume;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionPanel;
    public GameObject creditosPanel;
    

    private void Awake(){  // Los sliders estan a la espera de la interaccion
        volumenFX.onValueChanged.AddListener(CambiarVolumenFX);
        volumenMaster.onValueChanged.AddListener(CambiarVolumenMaster);
    }

    public void JugarJuego(string juego){  // Cambiar a escena del juego
        if(juego=="SampleScene"){ // Si se reinicia el juego
            Time.timeScale = 1;
            VidasPlayer.vidasINI = VidasPlayer.vidasReset;
        }
        SceneManager.LoadScene(juego);
    }

    public void AbrirMainMenu(string escena){
        SceneManager.LoadScene(escena);
    }

    public void SalirJuego(){
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

    public void PlaySoundDisparo(){
        fxSource.PlayOneShot(disparo);
    }

}
