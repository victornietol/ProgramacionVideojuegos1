using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Options")]
    //public Slider volumenFX;
    //public Slider volumenMaster;
    //public AudioMixer mixer;
    public AudioSource reproductor, reproductorClick;
    public AudioClip sonidoClick, sonidoFondo; //disparo;
    //private float lastVolume;
    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionPanel;
    public GameObject creditosPanel;

    void Start() {
        reproductor.PlayOneShot(sonidoFondo);
        Cursor.visible = true;
    }

    public void JugarJuego(string juego){  // Cambiar a escena del juego
        reproductorClick.PlayOneShot(sonidoClick);
        if (juego=="SampleScene"){ // Si se reinicia el juego
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(juego);
    }

    public void AbrirMainMenu(string escena){
        SceneManager.LoadScene(escena);
    }

    public void SalirJuego(){
        reproductorClick.PlayOneShot(sonidoClick);
        Application.Quit();
    }

    public void AbrirPanel(GameObject panel){
        Time.timeScale = 0;
        mainPanel.SetActive(false);
        optionPanel.SetActive(false);
        creditosPanel.SetActive(false);
        panel.SetActive(true);
        reproductorClick.PlayOneShot(sonidoClick);
    }

    public void CerrarPanel(){
        Time.timeScale = 1;
        mainPanel.SetActive(false);
        reproductorClick.PlayOneShot(sonidoClick);
    }

    // Activar sonido de los click en los botones
    /*
    public void PlaySoundButton(){
        fxSource.PlayOneShot(clickSound);
    }    */
}
