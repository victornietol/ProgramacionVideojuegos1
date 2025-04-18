using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ColisionesPlayer : MonoBehaviour
{
    public AudioSource reproductor, reproductorAmbiente, reproductorSt, repDo, repRe, repMi, repFa, repSol, repLa, repSi, reproductorMusica;

    public AudioClip fuenteAgua, ambiente, teclaDo, teclaRe, teclaMi, teclaFa, teclaSol, teclaLa, teclaSi, sonidoTorres, iglesia, ambienteCiudad, delfin, clickBoton;
    public AudioClip soundtrack2015, soundtrack2016, soundtrack2017, soundtrack2018, soundtrack2019, soundtrack2020, soundtrack2021, soundtrack2022; // soundtracks de juegos
    private AudioClip soundtrackTocar; // sonido a reproducir

    public Image principalGotys, imgGoty2015, imgGoty2016, imgGoty2017, imgGoty2018, imgGoty2019, imgGoty2020, imgGoty2021, imgGoty2022; // imagenes juegos

    public GameObject descGoty2015, descGoty2016, descGoty2017, descGoty2018, descGoty2019, descGoty2020, descGoty2021, descGoty2022, descTorres; // descripciones
    public GameObject videoGoty2015, videoGoty2016, videoGoty2017, videoGoty2018, videoGoty2019, videoGoty2020, videoGoty2021, videoGoty2022; // se mapea sobre cualquier objeto
    public GameObject heart;

    public Animator animImgGoty2015, animImgGoty2016, animImgGoty2017, animImgGoty2018, animImgGoty2019, animImgGoty2020, animImgGoty2021, animImgGoty2022;  // animaciones
    public Animator animDescGoty2015, animDescGoty2016, animDescGoty2017, animDescGoty2018, animDescGoty2019, animDescGoty2020, animDescGoty2021, animDescGoty2022, animTorres;
    public Animator animBocina0, animBocina1, animBocina2, animBtn2015, animBtn2016, animBtn2017, animBtn2018, animBtn2019, animBtn2020, animBtn2021, animBtn2022, animHeart;


    void Start() {
        Time.timeScale = 1;
        Cursor.visible=false;
        reproductorAmbiente.PlayOneShot(ambiente);
        principalGotys.gameObject.SetActive(false);
        descTorres.gameObject.SetActive(false);
        heart.gameObject.SetActive(false);

        imgGoty2015.gameObject.SetActive(false);
        imgGoty2016.gameObject.SetActive(false);
        imgGoty2017.gameObject.SetActive(false);
        imgGoty2018.gameObject.SetActive(false);
        imgGoty2019.gameObject.SetActive(false);
        imgGoty2020.gameObject.SetActive(false);
        imgGoty2021.gameObject.SetActive(false);
        imgGoty2022.gameObject.SetActive(false);

        descGoty2015.gameObject.SetActive(false);
        descGoty2016.gameObject.SetActive(false);
        descGoty2017.gameObject.SetActive(false);
        descGoty2018.gameObject.SetActive(false);
        descGoty2019.gameObject.SetActive(false);
        descGoty2020.gameObject.SetActive(false);
        descGoty2021.gameObject.SetActive(false);
        descGoty2022.gameObject.SetActive(false);

        videoGoty2015.SetActive(false);
        videoGoty2016.SetActive(false);
        videoGoty2017.SetActive(false);
        videoGoty2018.SetActive(false);
        videoGoty2019.SetActive(false);
        videoGoty2020.SetActive(false);
        videoGoty2021.SetActive(false);
        videoGoty2022.SetActive(false);
    }

    private void OnTriggerEnter(Collider obj) {
        if(obj.tag == "fuenteAgua") {
            reproductor.PlayOneShot(fuenteAgua);
        }
        if(obj.tag == "principalGOTYs") {
            principalGotys.gameObject.SetActive(true);
        }
        if (obj.tag == "torres") {
            descTorres.gameObject.SetActive(true);
            animTorres.Play("descTorres");
            reproductorMusica.PlayOneShot(sonidoTorres);
        }
        if (obj.tag == "bocinas") {
            if(soundtrackTocar==null) {
                soundtrackTocar = soundtrack2022;
            }
            animBocina0.Play("bocinaEncendida1");
            animBocina1.Play("bocinaEncendida2");
            animBocina2.Play("bocinaEncendida3");
            reproductorSt.PlayOneShot(soundtrackTocar);
        }
        if (obj.tag == "delfin") {
            heart.gameObject.SetActive(true);
            animHeart.Play("heart");
            reproductorMusica.PlayOneShot(delfin);
        }
        if (obj.tag == "st2015") {
            soundtrackTocar = soundtrack2015;
            animBtn2015.Play("btn2015");
            reproductorMusica.PlayOneShot(clickBoton);
            reproductorSt.Stop();
            reproductorSt.PlayOneShot(soundtrackTocar);
        }
        if (obj.tag == "st2016") {
            soundtrackTocar = soundtrack2016;
            animBtn2016.Play("btn2016");
            reproductorMusica.PlayOneShot(clickBoton);
            reproductorSt.Stop();
            reproductorSt.PlayOneShot(soundtrackTocar);
        }
        if (obj.tag == "st2017") {
            reproductorMusica.PlayOneShot(clickBoton);
            animBtn2017.Play("btn2017");
            soundtrackTocar = soundtrack2017;
            reproductorSt.Stop();
            reproductorSt.PlayOneShot(soundtrackTocar);
        }
        if (obj.tag == "st2018") {
            reproductorMusica.PlayOneShot(clickBoton);
            animBtn2018.Play("btn2018");
            soundtrackTocar = soundtrack2018;
            reproductorSt.Stop();
            reproductorSt.PlayOneShot(soundtrackTocar);
        }
        if (obj.tag == "st2019") {
            reproductorMusica.PlayOneShot(clickBoton);
            animBtn2019.Play("btn2019");
            soundtrackTocar = soundtrack2019;
            reproductorSt.Stop();
            reproductorSt.PlayOneShot(soundtrackTocar);
        }
        if (obj.tag == "st2020") {
            reproductorMusica.PlayOneShot(clickBoton);
            animBtn2020.Play("btn2020");
            soundtrackTocar = soundtrack2020;
            reproductorSt.Stop();
            reproductorSt.PlayOneShot(soundtrackTocar);
        }
        if (obj.tag == "st2021") {
            reproductorMusica.PlayOneShot(clickBoton);
            animBtn2021.Play("btn2021");
            soundtrackTocar = soundtrack2021;
            reproductorSt.Stop();
            reproductorSt.PlayOneShot(soundtrackTocar);
        }
        if (obj.tag == "st2022") {
            reproductorMusica.PlayOneShot(clickBoton);
            animBtn2022.Play("btn2022");
            soundtrackTocar = soundtrack2022;
            reproductorSt.Stop();
            reproductorSt.PlayOneShot(soundtrackTocar);
        }
        if (obj.tag == "goty2015") {
            videoGoty2015.SetActive(true);
            imgGoty2015.gameObject.SetActive(true);
            descGoty2015.gameObject.SetActive(true);
            animImgGoty2015.Play("imgGoty2015");
            animDescGoty2015.Play("descGoty2015");
        }
        if (obj.tag == "goty2016") {
            videoGoty2016.SetActive(true);
            imgGoty2016.gameObject.SetActive(true);
            descGoty2016.gameObject.SetActive(true);
            animImgGoty2016.Play("imgGoty2016");
            animDescGoty2016.Play("descGoty2016");
        }
        if (obj.tag == "goty2017") {
            videoGoty2017.SetActive(true);
            imgGoty2017.gameObject.SetActive(true);
            descGoty2017.gameObject.SetActive(true);
            animImgGoty2017.Play("imgGoty2017");
            animDescGoty2017.Play("descGoty2017");
        }
        if (obj.tag == "goty2018") {
            videoGoty2018.SetActive(true);
            imgGoty2018.gameObject.SetActive(true);
            descGoty2018.gameObject.SetActive(true);
            animImgGoty2018.Play("imgGoty2018");
            animDescGoty2018.Play("descGoty2018");
        }
        if (obj.tag == "goty2019") {
            videoGoty2019.SetActive(true);
            imgGoty2019.gameObject.SetActive(true);
            descGoty2019.gameObject.SetActive(true);
            animImgGoty2019.Play("imgGoty2019");
            animDescGoty2019.Play("descGoty2019");
        }
        if (obj.tag == "goty2020") {
            videoGoty2020.SetActive(true);
            imgGoty2020.gameObject.SetActive(true);
            descGoty2020.gameObject.SetActive(true);
            animImgGoty2020.Play("imgGoty2020");
            animDescGoty2020.Play("descGoty2020");
        }
        if (obj.tag == "goty2021") {
            videoGoty2021.SetActive(true);
            imgGoty2021.gameObject.SetActive(true);
            descGoty2021.gameObject.SetActive(true);
            animImgGoty2021.Play("imgGoty2021");
            animDescGoty2021.Play("descGoty2021");
        }
        if (obj.tag == "goty2022") {
            videoGoty2022.SetActive(true);
            imgGoty2022.gameObject.SetActive(true);
            descGoty2022.gameObject.SetActive(true);
            animImgGoty2022.Play("imgGoty2022");
            animDescGoty2022.Play("descGoty2022");
        }
        if (obj.tag == "do") {
            reproductor.PlayOneShot(teclaDo);
        }
        if (obj.tag == "re") {
            reproductor.PlayOneShot(teclaRe);
        }
        if (obj.tag == "mi") {
            reproductor.PlayOneShot(teclaMi);
        }
        if (obj.tag == "fa") {
            reproductor.PlayOneShot(teclaFa);
        }
        if (obj.tag == "sol") {
            reproductor.PlayOneShot(teclaSol);
        }
        if (obj.tag == "la") {
            reproductor.PlayOneShot(teclaLa);
        }
        if (obj.tag == "si") {
            reproductor.PlayOneShot(teclaSi);
        }
        if (obj.tag == "coches") {
            reproductorAmbiente.Stop();
            reproductorAmbiente.PlayOneShot(ambienteCiudad);
        }
        if (obj.tag == "iglesia") {
            reproductor.PlayOneShot(iglesia);
        }
        if (obj.tag == "menu") {
            SceneManager.LoadScene("mainMenu");
        }
        if (obj.tag == "salir") {
            Application.Quit();
        }
    }

    private void OnTriggerExit(Collider obj) {
        reproductor.Stop();
        if (obj.tag == "principalGOTYs") {
            principalGotys.gameObject.SetActive(false);
        }
        if (obj.tag == "torres") {
            reproductorMusica.Stop();
            animTorres.Play("descTorresOcultar");
        }
        if (obj.tag == "bocinas") {
            reproductorSt.Stop();
            animBocina0.Play("bocinaApagada1");
            animBocina1.Play("bocinaApagada2");
            animBocina2.Play("bocinaApagada3");
        }
        if (obj.tag == "delfin") {
            reproductorMusica.Stop();
            animHeart.Play("heatOcultar");
        }
        if (obj.tag == "goty2015") {
            animImgGoty2015.Play("imgGoty2015ocultar");
            animDescGoty2015.Play("descGoty2015Ocultar");
            videoGoty2015.SetActive(false);
        }
        if (obj.tag == "goty2016") {
            animImgGoty2016.Play("imgGoty2016Ocultar");
            animDescGoty2016.Play("descGoty2016Ocultar");
            videoGoty2016.SetActive(false);
        }
        if (obj.tag == "goty2017") {
            animImgGoty2017.Play("imgGoty2017Ocultar");
            animDescGoty2017.Play("descGoty2017Ocultar");
            videoGoty2017.SetActive(false);
        }
        if (obj.tag == "goty2018") {
            animImgGoty2018.Play("imgGoty2018Ocultar");
            animDescGoty2018.Play("descGoty2018Ocultar");
            videoGoty2018.SetActive(false);
        }
        if (obj.tag == "goty2019") {
            animImgGoty2019.Play("imgGoty2019Ocultar");
            animDescGoty2019.Play("descGoty2019Ocultar");
            videoGoty2019.SetActive(false);
        }
        if (obj.tag == "goty2020") {
            animImgGoty2020.Play("imgGoty2020Ocultar");
            animDescGoty2020.Play("descGoty2020Ocultar");
            videoGoty2020.SetActive(false);
        }
        if (obj.tag == "goty2021") {
            animImgGoty2021.Play("imgGoty2021Ocultar");
            animDescGoty2021.Play("descGoty2021Ocultar");
            videoGoty2021.SetActive(false);
        }
        if (obj.tag == "goty2022") {
            animImgGoty2022.Play("imgGoty2022Ocultar");
            animDescGoty2022.Play("descGoty2022Ocultar");
            videoGoty2022.SetActive(false);
        }
        if (obj.tag == "coches") {
            reproductorAmbiente.Stop();
            reproductorAmbiente.PlayOneShot(ambiente);
        }
    }
}
