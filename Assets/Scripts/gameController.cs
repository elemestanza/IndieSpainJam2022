using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    //Variables
    private GameObject player;
    private GameObject[] enemies;

    private PlayerBehaviour playerBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
