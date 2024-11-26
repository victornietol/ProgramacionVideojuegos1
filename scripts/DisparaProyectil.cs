using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparaProyectil : MonoBehaviour
{
    [SerializeField] private float velocidad = 8.0f; //le ponemos el serializeField para acceder a ella desde unity

    void FixedUpdate(){ // con esto hacemos el calculo de posiciones de la bala, del prefab
        if(CAD.dirDisparo == 1){ //disparo hacia abajo  
            transform.position += new Vector3(0, -1, 0) * Time.deltaTime * velocidad;
        } else if (CAD.dirDisparo == 2){ // disparo hacia arriba
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * velocidad;
        } else if (CAD.dirDisparo == 3){ // dispara hacia la izquierda
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
        } else if (CAD.dirDisparo == 4){ // disparo hacia la derecha
            transform.position += new Vector3(1, 0, 0) * Time.deltaTime * velocidad; 
            
            // Disparos diagonales
        } else if (CAD.dirDisparo == 5){ // Disparo diagonal arriba-derecha
            transform.position += new Vector3(1, 1, 0) * Time.deltaTime * velocidad;
        } else if (CAD.dirDisparo == 6){ // Disparo diagonal arriba-izquierda
            transform.position += new Vector3(-1, 1, 0) * Time.deltaTime * velocidad;
        } else if (CAD.dirDisparo == 7){ // Disparo diagonal abajo-derecha
            transform.position += new Vector3(1, -1, 0) * Time.deltaTime * velocidad;
        } else if (CAD.dirDisparo == 8){ // Disparo diagonal abajo-izquierda
            transform.position += new Vector3(-1, -1, 0) * Time.deltaTime * velocidad;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){ // y esto es para ver las colisiones de la bala 
        if(collision.gameObject.tag == "limites"){ // si choca con un limite la destruye 
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "enemigo"){ // si choca con un enemigo, la destruye y hace danio al enemigo
            collision.transform.GetComponent<Enemigo>().TomarDanio(1); // aqui le hace uno de danio al enemigo, por si lo queremos cambiar despues dependiendo de la vida del enemigo
            Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "jefeFinal"){ // si choca con un enemigo, la destruye y hace danio al enemigo
            collision.transform.GetComponent<JefeFinal>().TomarDanio(1); // aqui le hace uno de danio al enemigo, por si lo queremos cambiar despues dependiendo de la vida del enemigo
            Destroy(this.gameObject);
        }
    }
}
