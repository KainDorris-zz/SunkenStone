using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterScriptableObject", menuName = "SunkenStone/Monsters/MonsterScriptableObject", order = 0)]
public class MonsterScriptableObject : ScriptableObject {
    [Header("Monster Properties")]
    [SerializeField] public float health;
    [SerializeField] public float speed;
    [SerializeField] public float attackSpeed;
    [SerializeField] public float attackCoolDown;
    [SerializeField] public float damage;
    [SerializeField] public float stopDistance;
    [SerializeField] public Sprite sprite;
    [SerializeField] public List<DamageType> weaknesses;
    [SerializeField] public List<DamageType> resistances;


    [Header("Minion Properties")]
    [SerializeField] public string name;
    [SerializeField] public string description;
    [SerializeField] public bool isCollected;
}
