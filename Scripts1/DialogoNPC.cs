using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoNPC : MonoBehaviour
{
    public GameObject txtDialogo;

    private void OnMouseDown(){ //detecta el click del mouse
        this.gameObject.SetActive(false); //oculta el dialogo como tal
    }
}