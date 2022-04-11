using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider) {
        if (collider.GetComponent<PlayerContol>() != null)
            SceneManager.LoadScene(1);
    }
}
