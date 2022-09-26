using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Variables
    public GameObject[] enemyPrefabs;

    [SerializeField] private int numEnemies;
    private List<GameObject> enemies;
    private GameObject player;
    private PlayerBehaviour playerBehaviour;

    private GameObject gameManager;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerBehaviour = player.GetComponent<PlayerBehaviour>();

        enemies = new List<GameObject>();
        enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        numEnemies = enemies.Count;
        Debug.Log("Hay " + numEnemies + " enemigos.");

        GameObject gameManager = GameObject.Find("GameManager");
        DontDestroyOnLoad(gameManager);
    }

    // Update is called once per frame
    void Update() {

        if (playerBehaviour.Floor == 101)
        {
            enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            numEnemies = enemies.Count;
            playerBehaviour.Floor = 1;
            Debug.Log("Hay " + numEnemies + " enemigos.");
        }

        if (playerBehaviour.Floor == 102)
        {
            enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            numEnemies = enemies.Count;
            playerBehaviour.Floor = 2;
            Debug.Log("Hay " + numEnemies + " enemigos.");
        }

        if (playerBehaviour.Floor == 103)
        {
            enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            numEnemies = enemies.Count;
            playerBehaviour.Floor = 3;
            Debug.Log("Hay " + numEnemies + " enemigos.");
        }

        if (playerBehaviour.Floor == 104)
        {
            enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
            numEnemies = enemies.Count;
            playerBehaviour.Floor = 4;
            Debug.Log("Hay " + numEnemies + " enemigos.");
        }

        if (enemies.Count < numEnemies)
        {
            Debug.Log("Crear enemigo");
            generateEnemy();
        }
    }

    void generateEnemy() {
        int maxEnemy = 9;
        Vector3 position = new Vector3();
        switch (playerBehaviour.Floor) {
            case 1:
                maxEnemy = 8;
                position = new Vector3(-7.03f, 27.7f, -252.41f);
                break;
            case 2:
                maxEnemy = 17;
                position = new Vector3(13.45f, 38.29f, -196.18f);
                break;
            case 3:
                maxEnemy = 17;
                position = new Vector3(86.01f, 52.97f, -251.43f);
                break;
            case 4:
                position = new Vector3(-86.53f, 97.84f, -326.63f);
                break;
            default:
                position = new Vector3(-4.663f, 37.417f, -220.73f);
                break;
        }
        int nextEnemy = Random.Range(1, maxEnemy + 1) - 1;
        
        //Hay que decidir en qué puntos aparecen los enemigos
        GameObject enemyCreated = Instantiate(enemyPrefabs[nextEnemy], position, Quaternion.identity);
        enemies.Add(enemyCreated);
        Debug.Log("Num enemigos: " + enemies.Count);
    }

    public void destroyEnemy(GameObject e)
    {
        enemies.Remove(e);
        Destroy(e);
        Debug.Log("Num enemigos: " + enemies.Count);
    }

}