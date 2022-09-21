using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Variables
    public GameObject[] enemyPrefabs;

    private int numEnemies;
    private List<GameObject> enemies;
    private GameObject player;
    private PlayerBehaviour playerBehaviour;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerBehaviour = player.GetComponent<PlayerBehaviour>();

        enemies = new List<GameObject>();
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        numEnemies = enemies.Count;
    }

    // Update is called once per frame
    void Update() {
        if (enemies.Count < numEnemies) generateEnemy();
    }

    void generateEnemy() {
        int maxEnemy = 9;
        Vector3 position = new Vector3();
        switch (playerBehaviour.Floor) {
            case 1:
                maxEnemy = 2;
                position = new Vector3(-4.663f, 37.417f, -220.73f);
                break;
            case 2:
                maxEnemy = 4;
                position = new Vector3(41.426f, 45.614f, -195.43f);
                break;
            case 3:
                maxEnemy = 6;
                position = new Vector3(68.28f, 62.478f, -255.772f);
                break;
            case 4:
                position = new Vector3(-74.57f, 100.361f, -293.81f);
                break;
            default:
                position = new Vector3(-4.663f, 37.417f, -220.73f);
                break;
        }
        int nextEnemy = Random.Range(1, maxEnemy + 1) - 1;
        
        //Hay que decidir en qué puntos aparecen los enemigos
        GameObject enemyCreated = Instantiate(enemyPrefabs[nextEnemy], position, Quaternion.identity);
        enemies.Add(enemyCreated);
    }
}