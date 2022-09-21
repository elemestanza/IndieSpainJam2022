using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    //Variables
    public int doorTarget;
    public GameObject hologram;

    private GameObject player;
    private PlayerBehaviour playerBehaviour;
    private Collider hologramCollider;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerBehaviour = player.GetComponent<PlayerBehaviour>();
        hologramCollider = hologram.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            if (playerBehaviour.PuntParcial >= doorTarget && !hologramCollider.isTrigger) {
                hologramCollider.isTrigger = true;
                playerBehaviour.Floor += 1;
                playerBehaviour.PuntParcial = 0;
            }
        }
    }
}
