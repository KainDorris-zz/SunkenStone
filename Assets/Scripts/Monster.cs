
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Monster
{
    private Guid _id;
    private string _name;
    private string _description;
    private Sprite _sprite; // Later may need to be a List<Sprite> _spriteSet
    private Dictionary<string, float> _stats;
    private bool _isCollected;
    
    public Monster(string name, string description, bool isCollected, Dictionary<string, float> stats)
    {
        _id = new Guid();
        _name = name;
        _description = description;
        _isCollected = isCollected;
        _stats = stats;
        _sprite = Resources.Load<Sprite>($"Monsters/{name}"); // Later may need to be a List<Sprite> _spriteSet
    }

    // Cloning Constructor
    public Monster(Monster monster)
    {
        _id = monster._id;
        _name = monster._name;
        _description = monster._description;
        _isCollected = monster._isCollected;
        _stats = monster._stats;
        _sprite = monster._sprite;
    }

    public Guid GetId()
    {
        return _id;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public Sprite GetSprite() // Later may need to be List<Sprite>
    {
        return _sprite;
    }

    public Dictionary<string, float> GetStats()
    {
        return _stats;
    }

    public bool GetIsCollected()
    {
        return _isCollected;
    }

    public void SetIsCollected(bool isCollected)
    {
        _isCollected = isCollected;
    }
    
}