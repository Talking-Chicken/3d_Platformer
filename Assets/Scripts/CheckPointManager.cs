using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointManager : MonoBehaviour
{
    public static CheckPoint currentCheckpoint;
    private PlayerContol player;
    
    void Start() {
        player = FindObjectOfType<PlayerContol>();
    }

    void Update()
    {
         if(player.transform.position.y < transform.position.y)
         {
             SceneManager.LoadScene(0);
         }
    }
    
}