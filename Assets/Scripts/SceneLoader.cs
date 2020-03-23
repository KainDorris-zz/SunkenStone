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
        Application.Quit();
    }
}
