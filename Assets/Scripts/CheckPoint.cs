using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.GetComponent<PlayerContol>() != null)
            CheckPointManager.currentCheckpoint = this;
    }
}
