using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{

    public int totalLives = 3;
    private int currentLives;

    public Image[] lifeImages;
    public GameObject gameOverButton;

    void Start()
    {
        currentLives = totalLives;
        UpdateLifeCounter();
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Car") || other.CompareTag("Dog")){
            currentLives--;
            if(currentLives <= 0){
                GameOver();
            }else{
                UpdateLifeCounter();
            }
        }
    }

    void UpdateLifeCounter(){
        for(int i=0; i<lifeImages.Length; i++){
            if(i<currentLives){
                lifeImages[i].enabled = true;
            }else{
                lifeImages[i].enabled = false;
            }
        }
    }
    
    private void GameOver(){
        gameOverButton.gameObject.SetActive(true);
    }
}
