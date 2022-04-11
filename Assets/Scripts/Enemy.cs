using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerContol player;
    [SerializeField] private float speed, offsetY, offsetZ;
    private bool isAccelerating = false;
    void Start()
    {
        player = FindObjectOfType<PlayerContol>();

        //set position to player's back
        if (PlayerPrefs.HasKey("spawnX")) {
            Vector3 playerPos = new Vector3(PlayerPrefs.GetFloat("spawnX"), PlayerPrefs.GetFloat("spawnY"), PlayerPrefs.GetFloat("spawnZ"));
            transform.position = playerPos + new Vector3(0, offsetY, offsetZ);
        } else {
            transform.position = player.transform.position + new Vector3(0, offsetY, offsetZ);
        }
        
    }

    void Update() {
        if (Vector3.Distance(transform.position, player.transform.position) > 10.0f) {
            isAccelerating = true;
        }
    }

    void FixedUpdate() {
        //it will move toward player
        if (!isAccelerating)
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        else
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed + 0.1f);
        transform.rotation = Quaternion.LookRotation(player.transform.position);
    }

    
}
