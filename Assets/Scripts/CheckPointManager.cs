using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPoint currentCheckpoint;
    private PlayerContol player;
    void Start()
    {
        player = FindObjectOfType<PlayerContol>();
    }

    
    void Update()
    {
        if (player.transform.position.y < transform.position.y) {
            respawn();
            Debug.Log("respawn");
            Debug.Log("player: " + player.transform.position.y +" level:" + transform.position.y);
        }
    }

    public void respawn() {
        player.transform.position = currentCheckpoint.transform.position;
    }
}
