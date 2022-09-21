using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Variables
    public GameObject operatorsParent;

    private int puntPlayer;
    private int puntParcial;
    private int floor;
    private EnemyBehaviour enemyBehaviour;
    private OperatorsBehaviour operatorsBehaviour;
    private int activeOperator;
    public int PuntPlayer { get => puntPlayer; set => puntPlayer = value; }
    public int Floor { get => floor; set => floor = value; }
    public int PuntParcial { get => puntParcial; set => puntParcial = value; }

    // Start is called before the first frame update
    void Start() {
        PuntPlayer = 0;
        PuntParcial = 0;
        operatorsBehaviour = operatorsParent.GetComponent<OperatorsBehaviour>();
        Floor = 1;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy") {
            int puntParcialBefore = PuntParcial;
            GameObject enemy = collision.gameObject;
            enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            activeOperator = operatorsBehaviour.ActiveOperator;
            switch (activeOperator) {
                case 0:
                    PuntParcial += enemyBehaviour.digito;
                    break;
                case 1:
                    PuntParcial -= enemyBehaviour.digito;
                    break;
                case 2:
                    PuntParcial *= enemyBehaviour.digito;
                    break;
                case 3:
                    PuntParcial /= enemyBehaviour.digito;
                    break;
                default: break;
            }
            PuntPlayer += (PuntParcial - puntParcialBefore);
            Destroy(enemy);
        }
    }

}
