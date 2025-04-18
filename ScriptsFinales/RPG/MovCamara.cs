using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCamara : MonoBehaviour
{
    public Camera camara;
    
    private void OnTriggerEnter2D(Collider2D obj){
        // Portales Bosque
        if(obj.gameObject.tag == "portalBosqueDer"){   // Portal a Mansion
            Vector3 posicioncamara = new Vector3(34.7f,0.02f,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(20.8f,-2.02f,0);
            this.transform.position = posicionPlayer;
        }

        if(obj.gameObject.tag == "portalBosqueCueva"){   // Portal a Cueva
            Vector3 posicioncamara = new Vector3(-0.03f,22.27f,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-12.42f,15.7f,0);
            this.transform.position = posicionPlayer;
        }

        if(obj.gameObject.tag == "portalBosqueAbajo"){  // Portal Bosque Abajo
            Vector3 posicioncamara = new Vector3(-0.3f,-23.4f,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(4,-16.5f,0);
            this.transform.position = posicionPlayer;
        }

        // Portales Mansion Enfrente
        if(obj.gameObject.tag == "portalEntradaMansion"){  // Portal Hacia Dentro de Mansion
            if(Inventario.existeLlave){
                Vector3 posicioncamara = new Vector3(34.4f,26.2f,-10);
                camara.transform.position = posicioncamara;
                Vector3 posicionPlayer = new Vector3(34.46f,19.03f,0);
                this.transform.position = posicionPlayer;
            } else {
                GameObject.Find("/Canvas/fondoPlayer/advertenciaMansion").SetActive(true);
            }
        }

        if(obj.gameObject.tag == "portalRegresoBosqueMansion"){  // Portal Regreso al Bosque Mansion
            Vector3 posicioncamara = new Vector3(0,0,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(14.2f,-1.77f,0);
            this.transform.position = posicionPlayer;
        }

        // Portal Cueva 
        if(obj.gameObject.tag == "portalRegresoBosqueCueva"){  // Portal Regreso al Bosque 
            Vector3 posicioncamara = new Vector3(0,0,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-12.3f,5.16f,0);
            this.transform.position = posicionPlayer;
        }

        // Portales Parque
        if(obj.gameObject.tag == "portalParqueIzq"){  // Portal Hacia la Ciudad
            Vector3 posicioncamara = new Vector3(-38.4f,-23,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-24.26f,-23.07f,0);
            this.transform.position = posicionPlayer;
        }

        if(obj.gameObject.tag == "portalParqueArriba"){  // Portal Hacia el Bosque
            Vector3 posicioncamara = new Vector3(0,0,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(3.7f,-6.46f,0);
            this.transform.position = posicionPlayer;
        }

        // Portales Ciudad
        if(obj.gameObject.tag == "portalCiudadDer"){  // Portal Hacia el Parque
            Vector3 posicioncamara = new Vector3(0.95f,-23,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-13.6f,-23.07f,0);
            this.transform.position = posicionPlayer;
        }

        if(obj.gameObject.tag == "portalCiudadAbajo"){  // Portal Hacia Casa Unica
            Vector3 posicioncamara = new Vector3(-37.9f,-46.3f,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-38.51f,-38.97f,0);
            this.transform.position = posicionPlayer;
        }

        // Portales Casa Unica
        if(obj.gameObject.tag == "portalCasaUnicaArriba"){  // Portal Hacia Ciudad
            Vector3 posicioncamara = new Vector3(-38.4f,-23,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(-38.51f,-30.1f,0);
            this.transform.position = posicionPlayer;
        }

        // Portales Mansion Dentro
        if(obj.gameObject.tag == "portalSalidaMansion"){   // Portal a Mansion Fuera
            Vector3 posicioncamara = new Vector3(34.7f,0.02f,-10);
            camara.transform.position = posicioncamara;
            Vector3 posicionPlayer = new Vector3(34.46f,-0.19f,0);
            this.transform.position = posicionPlayer;
        }
    }

}
