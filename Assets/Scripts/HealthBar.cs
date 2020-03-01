using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    //refs 
    [SerializeField] Player player;
    float playerHealth;
    float healthBarMax;
    Slider slider;
    private void Start() {
        slider = gameObject.GetComponent<Slider>();
        slider.highValue = player.GetMaxHealth();
        playerHealth = player.GetCurrentHealth();
        

    }   


    private void Update() {
        slider.value = playerHealth;
    }

    private void UpdateEntityHealth(){
        playerHealth = player.GetCurrentHealth();
    }

}
