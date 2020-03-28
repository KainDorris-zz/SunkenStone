using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    
   [SerializeField] public GameObject mainMenu;
   [SerializeField] public InputManager inputManager;
   private bool menuActive = false;

    // Update is called once per frame
    void Start()
    {   
        
        mainMenu.SetActive(false);
    }

    private void Update() {
        if (Input.GetButtonDown("Cancel")){
            
            if (Time.timeScale == 1){
                
                OpenMenu();
                Time.timeScale = 0;
                
            }
            else if ( Time.timeScale == 0){
                Time.timeScale = 1;
                CloseMenu();
            }   
        }
    }

    private void OpenMenu(){
        
        mainMenu.SetActive(true);
        inputManager.gameObject.SetActive(false);
            
    }

    private void CloseMenu(){
        mainMenu.SetActive(false);
        inputManager.gameObject.SetActive(true);
        
    }
}
