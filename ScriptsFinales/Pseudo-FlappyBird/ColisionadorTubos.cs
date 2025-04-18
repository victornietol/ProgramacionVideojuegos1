using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionadorTubos : MonoBehaviour
{
    private GameObject[] grupoTubos;
    private float distancia;// = 3.0f;
    private float ultimaXTubo;
    private float yminTubo = -0.9f; // calibrar respecto de lo visto en el editor (DEFAULT=-2,2)
    private float ymaxTubo = 2.5f;

    void Awake() {
        grupoTubos = GameObject.FindGameObjectsWithTag("tuboGrupo");
        for(int i=0; i<grupoTubos.Length; i++) {
            Vector3 temp = grupoTubos[i].transform.position;
            temp.y = Random.Range(yminTubo,ymaxTubo);
            grupoTubos[i].transform.position = temp;
        }

        ultimaXTubo = grupoTubos[0].transform.position.x;

        for(int i=1; i<grupoTubos.Length; i++) {
            if(ultimaXTubo < grupoTubos[i].transform.position.x) {
                ultimaXTubo = grupoTubos[i].transform.position.x;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D obj) {
        if(obj.tag == "tuboGrupo") {
            distancia = Random.Range(2.0f,5.5f); // PRUEBAS
            Vector3 temp = obj.transform.position;
            temp.x = ultimaXTubo + distancia;
            temp.y = Random.Range(yminTubo,ymaxTubo);
            obj.transform.position = temp;
            ultimaXTubo = temp.x;
        }
    }

}
