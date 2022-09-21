using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDoorBehaviour : MonoBehaviour
{
    //Variables
    public GameObject controlledDoor;

    private Collider doorCollider;

    // Start is called before the first frame update
    void Start() {
        doorCollider = controlledDoor.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") doorCollider.isTrigger = false;
    }
}
