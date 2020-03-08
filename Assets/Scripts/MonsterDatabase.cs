using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class MonsterDatabase : MonoBehaviour
{
    [SerializeField] private List<Monster> monsters;

    private void Awake()
    {
        BuildMonsterDatabase();
    }

    public void BuildMonsterDatabase()
    {
        monsters = new List<Monster>()
        {
            new Monster("Monster1", "A placeholder monster", true,
                new Dictionary<string, float>
                {
                    {"Health", 25f},
                    {"Damage", 10f}
                }),
            new Monster("Monster2", "A placeholder monster", true,
                new Dictionary<string, float>
                {
                    {"Health", 25f},
                    {"Damage", 10f}
                }),
            new Monster("Monster3", "A placeholder monster", true,
                new Dictionary<string, float>
                {
                    {"Health", 25f},
                    {"Damage", 10f}
                }),
            new Monster("Monster4", "A placeholder monster", true,
                new Dictionary<string, float>
                {
                    {"Health", 25f},
                    {"Damage", 10f}
                }),
            new Monster("Monster5", "A placeholder monster", true,
                new Dictionary<string, float>
                {
                    {"Health", 25f},
                    {"Damage", 10f}
                }),
            new Monster("Monster6", "A placeholder monster", true,
                new Dictionary<string, float>
                {
                    {"Health", 25f},
                    {"Damage", 10f}
                }),
            new Monster("Monster7", "A placeholder monster", true,
                new Dictionary<string, float>
                {
                    {"Health", 25f},
                    {"Damage", 10f}
                }),
            new Monster("Monster8", "A placeholder monster", true,
                new Dictionary<string, float>
                {
                    {"Health", 25f},
                    {"Damage", 10f}
                }),
        };
    }

    public Monster GetMonsterByName(string monsterName)
    {
        return monsters.FirstOrDefault(m => m.GetName() == monsterName);
    }
    
    public Monster GetMonsterByGuid(Guid monsterId)
    {
        return monsters.FirstOrDefault(m => m.GetId() == monsterId);
    }

    public Monster GetMonsterBySprite(Sprite sprite)
    {
        return monsters.FirstOrDefault(m => m.GetSprite() == sprite);
    }

    public void AddMonster(Monster monster)
    {
        monsters.Add(monster);
    }

    public List<Monster> GetMonsters()
    {
        return monsters;
    }
}