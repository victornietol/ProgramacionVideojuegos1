using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientacionProyectil : MonoBehaviour
{
    public Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
    }

    void Update(){
        if(CAD.disparando==true){
            activaCapa("BalaMov");

            if (MovPlayer.dirAtaque == 1){
                anim.SetTrigger("bala1");
            } else if (MovPlayer.dirAtaque == 2){
                anim.SetTrigger("balaArriba");
            } else if (MovPlayer.dirAtaque == 3){
                anim.SetTrigger("balaIzquierda");
            } else if (MovPlayer.dirAtaque == 4){
                anim.SetTrigger("balaDerecha");
            }
        }
    }

    private void activaCapa(string nombre){
        Debug.Log("ACTIVACOOOOOOOOOOOOOOOON");
        for (int i = 0; i < anim.layerCount; i++){
            anim.SetLayerWeight(i, 0);
        }
        anim.SetLayerWeight(anim.GetLayerIndex(nombre), 1);
    }


}
