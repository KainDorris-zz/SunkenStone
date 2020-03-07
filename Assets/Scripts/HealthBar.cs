using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //refs 
    [SerializeField] Player player;
    float playerHealth;
    float healthBarMax;
    Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = player.GetMaxHealth();
        playerHealth = player.GetCurrentHealth();
    }


    private void Update() {
        UpdateEntityHealth();
    }

    private void UpdateEntityHealth(){
        playerHealth = player.GetCurrentHealth();
        slider.value = playerHealth;
    }

}
