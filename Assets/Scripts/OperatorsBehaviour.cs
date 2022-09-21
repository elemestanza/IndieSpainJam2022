using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorsBehaviour : MonoBehaviour
{
    public float tiempoCambio = 20.0f;
    public GameObject[] operators; //0: Suma, 1: Resta, 2: Multiplicación, 3: División

    private int activeOperator;
    private float countdown;

    // Start is called before the first frame update

    private void Awake() {
        foreach (GameObject o in operators)
        {
            o.SetActive(false);
        }
        operators[0].SetActive(true);
        activeOperator = 0;
    }
    void Start() {
        countdown = tiempoCambio;
    }

    // Update is called once per frame
    void Update() {
        countdown -= Time.deltaTime;
        if(countdown <= 0.0f) {
            cambioOperador();
        }
    }
    void cambioOperador() {
        operators[activeOperator].SetActive(false);
        int selectOperator = activeOperator;
        while (selectOperator == activeOperator) selectOperator = Random.Range(0, 4);
        activeOperator = selectOperator;
        operators[activeOperator].SetActive(true);
        countdown = tiempoCambio;
    }
    public int getActiveOperator() {
        return activeOperator;
    }
}
