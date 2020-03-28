using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadGame(){
        
        SceneManager.LoadScene("BuildTeam");
    }

    public void LoadOptions(){
        SceneManager.LoadScene("BuildTeam");
    }
    public void QuitGame(){
        Debug.Log("You quit the game");
        Application.Quit();
    }

    public void LoadMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
