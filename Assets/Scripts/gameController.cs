using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //Variables

    public GameObject[] enemyPrefabs;
    public int numEnemies = 10;

    private List<GameObject> enemies;

    private EnemyBehaviour enemyBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        for (int i = 0; i < numEnemies; i++) generateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count < numEnemies) generateEnemy();
    }

    void generateEnemy() {
        int num = Random.Range(0, 9);
        Vector3 position = new Vector3(); //Hay que decidir en qué area aparecen los enemigos
        GameObject enemyCreated = Instantiate(enemyPrefabs[num], position, Quaternion.identity);
        enemies.Add(enemyCreated);
    }
}
