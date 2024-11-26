using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColeccionablesPlayer : MonoBehaviour
{
    
    private GameObject player;
    public static string objAColeccionar;
    private Inventario inventario;
    private int vidaDiferencia;
    private int manaDiferencia; 

    void Start() {
        player = GameObject.Find("Player");
        objAColeccionar = "";
        inventario = FindObjectOfType<Inventario>();
    }

    private void OnTriggerEnter2D(Collider2D obj) {
        if (obj.tag == "vida") {
            if(VidasPlayer.vida<VidasPlayer.vidasINI){  // Si la vida es menor al limite de vida
                VidasPlayer.vida++;
                player.GetComponent<VidasPlayer>().DibujaVida(VidasPlayer.vida);
                Destroy(obj.gameObject);
            }
        }
        if (obj.tag == "vidaFull") {
            if(VidasPlayer.vida<VidasPlayer.vidasINI){  // Si la vida es menor al limite de vida
                vidaDiferencia = VidasPlayer.vidasINI-VidasPlayer.vida;
                VidasPlayer.vida+= vidaDiferencia;  // Depende del numero de vida total
                player.GetComponent<VidasPlayer>().DibujaVida(VidasPlayer.vida);
                Destroy(obj.gameObject);
            }
        }
        if (obj.tag == "mana") {
            if(ManaPlayer.mana<ManaPlayer.manasINI){
                ManaPlayer.mana++;
                player.GetComponent<ManaPlayer>().DibujaMana(ManaPlayer.mana);
                Destroy(obj.gameObject);
            }
        }
        if (obj.tag == "manaFull") {
            if(ManaPlayer.mana<ManaPlayer.manasINI){
                manaDiferencia = ManaPlayer.manasINI-ManaPlayer.mana;
                ManaPlayer.mana+= manaDiferencia;
                player.GetComponent<ManaPlayer>().DibujaMana(ManaPlayer.mana);
                Destroy(obj.gameObject);
            }
        }
        if (obj.tag == "mochila") {
            AplicaCambios(obj);
        }
        if (obj.tag == "carta") {
            AplicaCambios(obj);
        }
        if (obj.tag == "mapa") {
            AplicaCambios(obj);
        }
        if (obj.tag == "pergamino") {
            AplicaCambios(obj);
        }
        if (obj.tag == "libro") {
            AplicaCambios(obj);
        }
        if (obj.tag == "gemaRoja") {
            AplicaCambios(obj);
        }
        if (obj.tag == "gemaVerde") {
            AplicaCambios(obj);
        }
        if (obj.tag == "gemaAzul") {
            AplicaCambios(obj);
        }
        if (obj.tag == "cristal") {
            AplicaCambios(obj);
        }
        if (obj.tag == "diamante") {
            AplicaCambios(obj);
        }
    }
    
    private void AplicaCambios(Collider2D obj) {
        objAColeccionar = obj.tag;
        //Debug.Log(objAColeccionar);
        inventario.EscribeEnArreglo();
        Destroy(obj.gameObject);
    }
}
