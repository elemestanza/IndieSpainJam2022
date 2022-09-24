using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Variables
    public GameObject operatorsParent;

    public int puntPlayer;
    public int puntParcial;
    private int floor;
    public float timeLapse = 2.0f;
    private float countdown;
    public bool isAbleToOperate = true;

    private GameObject gM;
    private GameManager gameManager;
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
        countdown = timeLapse;

        gM = GameObject.Find("GameManager");
        gameManager = gM.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update() {
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
        {
            isAbleToOperate = true;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy" && isAbleToOperate) {
            operatorsBehaviour.operatorChange();
            Debug.Log("Sa chocao");

            countdown = timeLapse;
            isAbleToOperate = false;

            int puntParcialBefore = PuntParcial;
            GameObject enemy = collision.gameObject;
            enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            activeOperator = operatorsBehaviour.ActiveOperator;
            switch (activeOperator) {
                case 0:
                    Debug.Log("Sumando");
                    PuntParcial += enemyBehaviour.digito;
                    break;
                case 1:
                    Debug.Log("Restando");
                    PuntParcial -= enemyBehaviour.digito;
                    break;
                case 2:
                    Debug.Log("Multiplicando");
                    PuntParcial *= enemyBehaviour.digito;
                    break;
                case 3:
                    Debug.Log("Dividiendo");
                    PuntParcial /= enemyBehaviour.digito;
                    break;
                default: break;
            }
            if (PuntParcial < 0) PuntParcial = 0;
            PuntPlayer += (PuntParcial - puntParcialBefore);
            gameManager.destroyEnemy(enemy);
            Debug.Log("Parcial: " + PuntParcial + ", Total: " + PuntPlayer);
        }
    }

}
