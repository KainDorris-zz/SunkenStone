using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterDatabaseScriptableObject", menuName = "SunkenStone/MonsterDatabaseScriptableObject",
    order = 0)]
public class MonsterDatabaseScriptableObject : ScriptableObject
{
    [SerializeField] public List<MonsterScriptableObject> monsters;

    public List<MonsterScriptableObject> GetAll() => monsters;

    public List<MonsterScriptableObject> GetCollected() => monsters.Where(m => m.isCollected).ToList();

    public List<MonsterScriptableObject> GetUncollected() => monsters.Where(m => !m.isCollected).ToList();

    public MonsterScriptableObject GetMonsterBySprite(Sprite spr) => monsters.FirstOrDefault(m => m.sprite == spr);
}