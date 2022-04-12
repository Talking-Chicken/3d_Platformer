using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        if (PlayerPrefs.HasKey("Death Count")) {
            scoreText.text = "Congrats!\nYou finised game with " + PlayerPrefs.GetInt("Death Count") + " death";
        } else {
            scoreText.text = "Congrats!\nYou finised game with 0 death";
        }
    }
}
