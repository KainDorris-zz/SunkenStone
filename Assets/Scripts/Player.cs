using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private List<Minion> minions;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 5f;
    private int _level;
    private int _gold;
    
    void Start()
    {
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();
        SwapMinions(0);
    }

    public void SwapMinions(int slot)
    {
        Minion minion = minions[slot];
        SpriteRenderer minionSpriteRenderer = minion.GetSpriteRenderer();
        spriteRenderer.sprite = minionSpriteRenderer.sprite;
        spriteRenderer.color = minionSpriteRenderer.color;
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
}
