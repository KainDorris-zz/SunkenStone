using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Monster> minions;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 5f;
    private int _level;
    private int _gold;

    private float _currentHealth;

    private float _maxHealth = 100;
    
    void Start()
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        SwapMinions(0);
        _currentHealth = _maxHealth;
    }

    public void SwapMinions(int slot)
    {
        Monster minion = minions[slot];
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
        return minions;
    }
}
