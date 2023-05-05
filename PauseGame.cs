using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public GameObject paused;
    public Button resumeButton;
    public Button quitButton;

    private bool gamePaused = false;

    void Start()
    {
        paused.SetActive(false);
        resumeButton.onClick.AddListener(Resume);
        quitButton.onClick.AddListener(QuitGame);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gamePaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    void Pause(){
        Time.timeScale = 0f;
        gamePaused = true;
        paused.SetActive(true);
    }

    void Resume(){
        Time.timeScale = 1f;
        gamePaused = false;
        paused.SetActive(false);
    }

    void QuitGame(){
        Application.Quit();
    }
}
