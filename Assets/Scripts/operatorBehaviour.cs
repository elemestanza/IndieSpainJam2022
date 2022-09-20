using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class operatorBehaviour : MonoBehaviour
{
    private GameObject[] operators;
    private int operadorActivo;
    public float tiempoCambio = 20.0f;
    private float countdown;

    // Start is called before the first frame update
    void Start() {
        operators = GameObject.FindGameObjectsWithTag("Operator");
        
        foreach (GameObject o in operators){
            o.SetActive(false);
        }
        operators[0].SetActive(true);
        operadorActivo = 0;

        countdown = tiempoCambio;
    }

    // Update is called once per frame
    void Update() {
        countdown -= Time.deltaTime;
        if(countdown <= 0.0f) {
            cambioOperador();
            countdown = tiempoCambio;
        }
    }

    void cambioOperador() {
        operators[operadorActivo].SetActive(false);
        int selectOperador = operadorActivo;
        while (selectOperador == operadorActivo) selectOperador = Random.Range(0, 4);
        operadorActivo = selectOperador;
        operators[operadorActivo].SetActive(true);
    }
}
