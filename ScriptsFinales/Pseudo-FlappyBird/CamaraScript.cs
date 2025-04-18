using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{

    public static float offsetX;
    

    
    void Update() {
        if(Player.instancia != null) { // se mueve la camara
            if(Player.instancia.estaVivo) {
                MueveCamara();
            }
        }
    }

    private void MueveCamara() {
        Vector3 temp = transform.position;
        temp.x = Player.instancia.ObtenPosX() + offsetX;
        transform.position = temp;
    }

}
