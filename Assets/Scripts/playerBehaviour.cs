using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //Variables
    private int puntPlayer;

    // Start is called before the first frame update
    void Start()
    {
        puntPlayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getPuntPlayer()
    {
        return puntPlayer;
    }

    public void setPuntPlayer(int p)
    {
        puntPlayer = p;
    }
}
