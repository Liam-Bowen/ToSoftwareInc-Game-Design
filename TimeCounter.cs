using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeCounter : MonoBehaviour
{
    public TextMeshProUGUI countdownText;

    public float totalTime = 10f;
    private float remainingTime;
    //private bool timeIsUp = false;

    public GameObject gameOverButton;

    void Start()
    {
        remainingTime = totalTime;
    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
        if(remainingTime <= 0f){
            remainingTime = 0f;
            //timeIsUp = true;
            GameOver();
        }

        countdownText.text = "Time: " + remainingTime.ToString("0.#");
    }

    private void GameOver(){
        gameOverButton.gameObject.SetActive(true);
    }
}
