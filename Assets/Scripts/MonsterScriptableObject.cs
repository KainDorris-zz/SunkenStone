using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterScriptableObject", menuName = "SunkenStone/Monsters/MonsterScriptableObject", order = 0)]
public class MonsterScriptableObject : ScriptableObject {
    [SerializeField] public float health;
    [SerializeField] public float speed;
    [SerializeField] public float attackSpeed;
    [SerializeField] public float attackCoolDown;
    [SerializeField] public float damage;
    [SerializeField] public float stopDistance;

    [SerializeField] public Sprite enemySprite;
    
}
