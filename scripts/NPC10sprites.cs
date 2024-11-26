using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC10sprites : MonoBehaviour
{
    public GameObject txtDialogo; //necesita cuadro de dialogo
    public int numVisitas; //num de visitas 
    public Sprite txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9, txt10; 

    void Start(){
        txtDialogo.SetActive(false);
        numVisitas = 0; // de inicio el cuadro sea falso para que no aparezca y el num de visitas en cero 
    }

    private void OnTriggerEnter2D(Collider2D obj){
        if(obj.tag=="Player"){
            txtDialogo.SetActive(true); // para que el cuadro de dialogo se muestre
            EscribeDialogo(); // y que dialogo se va a mostrar, con la funcion privada de abajo
            numVisitas++;
        }
    }

    private void EscribeDialogo(){
        switch (numVisitas){
            case 0:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt1; // aqui lo que se dice es que el txtDialogo se cambie el sprite a el sprite que se muestra en txt1 
                break;
            case 1:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt2;
                break;
            case 2:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt3;
                break;
            case 3:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt4;
                break;
            case 4:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt5;
                break;
            case 5:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt6;
                break;
            case 6:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt7;
                break;
            case 7:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt8;
                break;
            case 8:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt9;
                break;    
            case 9:
                txtDialogo.GetComponent<SpriteRenderer>().sprite = txt10;
                break;
        }
    }
}