using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    private bool muestraInventario;
    public GameObject goInventario;
    [SerializeField] private string[] valoresInventario;
    private int numGemasVerdes, numGemasAzules, numGemasRojas, numDiamantes, numCristales;
    Button boton;
    public Sprite mochila, carta, mapa, pergamino, libro, gemaRoja, gemaVerde, gemaAzul, cristal, diamante, contenedor;


    void Start() {
        muestraInventario = false;
        BorraArreglo();
        numGemasAzules = 0;
        numGemasRojas = 0;
        numGemasVerdes = 0;
        numCristales = 0;
        numDiamantes = 0;
        //numPocionesVerdes = 0;
    }


    public void StatusInventario() {
        if (muestraInventario) {
            muestraInventario = false;
            goInventario.SetActive(false);
            Time.timeScale = 1;  // Sirve para detener lo que pasa en el juego mientras se esta en el inventario
        } else {
            muestraInventario = true;
            goInventario.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    public void EscribeEnArreglo() {
        if (VerificaEnArreglo() == -1) { // No esta en el inventario
            for (int i = 0; i < valoresInventario.Length; i++) {
                if (valoresInventario[i] == "") { // Lo colaca en la primera posicion vacia que encuentre
                    valoresInventario[i] = ColeccionablesPlayer.objAColeccionar;
                    DibujaElementos(i);
                    break;
                }
            }
        } else { // Si ya esta en el inventario, ubica su posicion y suma uno al elemento
            DibujaElementos(VerificaEnArreglo());
        }
    }

    private int VerificaEnArreglo() {
        int pos = -1;
        for (int i = 0;i < valoresInventario.Length;i++) {
            if (valoresInventario[i] == ColeccionablesPlayer.objAColeccionar) {
                pos  = i; 
                break;
            }
        }
        return pos;
    }

    public void DibujaElementos(int pos) {
        StatusInventario();
        boton = GameObject.Find("elemento ("+pos+")").GetComponent<Button>();
        switch (ColeccionablesPlayer.objAColeccionar){
            case "mochila":
                contenedor = mochila;
                break;
            case "carta":
                contenedor = carta;
                break;
            case "mapa":
                contenedor = mapa;
                break;
            case "pergamino":
                contenedor = pergamino;
                break;
            case "libro":
                contenedor = libro;
                break;
            case "gemaRoja":
                contenedor = gemaRoja;
                numGemasRojas++;
                boton.GetComponentInChildren<Text>().text = "x" + numGemasRojas.ToString();
                break;
            case "gemaVerde":
                contenedor = gemaVerde;
                numGemasVerdes++;
                boton.GetComponentInChildren<Text>().text = "x" + numGemasVerdes.ToString();
                break;
            case "gemaAzul":
                contenedor = gemaAzul;
                numGemasAzules++;
                boton.GetComponentInChildren<Text>().text = "x" + numGemasAzules.ToString();
                break;
            case "cristal":
                contenedor = cristal;
                numCristales++;
                boton.GetComponentInChildren<Text>().text = "x" + numCristales.ToString();
                break;
            case "diamante":
                contenedor = diamante;
                numDiamantes++;
                boton.GetComponentInChildren<Text>().text = "x" + numDiamantes.ToString();
                break;
            /*
            case "pocimaAzul":
                contenedor = pocionAzul;
                numPocionesRojas++;
                boton.GetComponentInChildren<Text>().text = "x" + numPocionesAzules.ToString();
                break;*/
        }
        //Debug.Log(contenedor);
        boton.GetComponent<Image>().sprite = contenedor;
    }
    

    private void BorraArreglo(){
        for (int i = 0; i < valoresInventario.Length; i++) {
            valoresInventario[i] = "";
        }
    }
    
}
