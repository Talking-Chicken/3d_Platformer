using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    void OnTriggerEnter(Collider collider) {
        if (collider.GetComponent<PlayerContol>() != null) {
            PlayerPrefs.SetFloat("spawnX", transform.position.x);
            PlayerPrefs.SetFloat("spawnY", transform.position.y);
            PlayerPrefs.SetFloat("spawnZ", transform.position.z);
        }
    }
}
