using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorsBehaviour : MonoBehaviour
{
    //Variables
    public float timeLapse = 20.0f;
    public GameObject[] operators; //0: Suma, 1: Resta, 2: Multiplicación, 3: División

    private int activeOperator;
    private float countdown;
    public int ActiveOperator { get => activeOperator; set => activeOperator = value; }

    // Start is called before the first frame update

    private void Awake() {
        foreach (GameObject o in operators)
        {
            o.SetActive(false);
        }
        operators[0].SetActive(true);
        ActiveOperator = 0;
    }
    void Start() {
        countdown = timeLapse;
    }

    // Update is called once per frame
    void Update() {
        countdown -= Time.deltaTime;
        if(countdown <= 0.0f) {
            operatorChange();
        }
    }
    void operatorChange() {
        operators[ActiveOperator].SetActive(false);
        int selectOperator = ActiveOperator;
        while (selectOperator == ActiveOperator) selectOperator = Random.Range(0, 4);
        ActiveOperator = selectOperator;
        operators[ActiveOperator].SetActive(true);
        countdown = timeLapse;
    }
}
