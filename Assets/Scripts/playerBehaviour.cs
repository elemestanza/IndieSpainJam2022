using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Variables
    public GameObject operatorsParent;

    private int puntPlayer;
    private EnemyBehaviour enemyBehaviour;
    private OperatorsBehaviour operatorsBehaviour;
    private int activeOperator;

    // Start is called before the first frame update
    void Start()
    {
        puntPlayer = 0;
        operatorsBehaviour = operatorsParent.GetComponent<OperatorsBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy") {
            GameObject enemy = collision.gameObject;
            enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            activeOperator = operatorsBehaviour.getActiveOperator();
            switch (activeOperator) {
                case 0:
                    puntPlayer += enemyBehaviour.digito;
                    break;
                case 1:
                    puntPlayer -= enemyBehaviour.digito;
                    break;
                case 2:
                    puntPlayer *= enemyBehaviour.digito;
                    break;
                case 3:
                    puntPlayer /= enemyBehaviour.digito;
                    break;
                default: break;
            }
            Destroy(enemy);
        }
    }
}
