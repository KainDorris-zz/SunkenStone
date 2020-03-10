using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 5f;
    
    private List<Monster> _minions;
    private int _level;
    private int _gold;

    private float _currentHealth;

    private float _maxHealth = 100;

    private void Awake()
    {
       _minions = TeamManager.PlayerTeam;
    }

    void Start()
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        SwapMinions(0);
        _currentHealth = _maxHealth;
    }

    public void SwapMinions(int slot)
    {
        if (_minions?[slot] == null) return; // This can likely be removed after game flow is finished.
        Monster minion = _minions[slot];
        Sprite minionSprite = minion.GetSprite();
        spriteRenderer.sprite = minionSprite;
    }
    
    public void TakeDamage(float dmg)
    {
        _currentHealth -= dmg;

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    public float GetSpeed()
    {
        return speed;
    }

    public int GetLevel()
    {
        return _level;
    }
    
    public int GetGold()
    {
        return _gold;
    }

    public float GetCurrentHealth()
    {
        return _currentHealth;
    }

    public float GetMaxHealth(){
        return _maxHealth;
    }

    public List<Monster> GetMinions()
    {
        return _minions;
    }
}
