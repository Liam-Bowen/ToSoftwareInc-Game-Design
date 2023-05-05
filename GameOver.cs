using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Button newGameButton;
    public Button quitGameButton;

    //private bool gameOver = false;

    void Start()
    {
        gameOverScreen.SetActive(false);
        newGameButton.onClick.AddListener(NewGame);
        quitGameButton.onClick.AddListener(QuitGame);
    }

    /**void GameOverScreen(){
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
    }**/

    void NewGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    void QuitGame(){
        Application.Quit();
    }
}
