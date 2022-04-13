using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPointManager : MonoBehaviour
{
    private PlayerContol player;
    
    void Start() {
        player = FindObjectOfType<PlayerContol>();
    }

    void Update()
    {
         if(player.transform.position.y < transform.position.y)
         {
            respawn();
         }
    }

    public static void respawn() {
        if (PlayerPrefs.HasKey("Death Count"))
            PlayerPrefs.SetInt("Death Count", PlayerPrefs.GetInt("Death Count") + 1);
        else
            PlayerPrefs.SetInt("Death Count", 1);

        Debug.Log("respawn");
        SceneManager.LoadScene(0);
    }
    
}
