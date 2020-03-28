using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "MonsterScriptableObject", menuName = "SunkenStone/MonsterScriptableObject", order = 0)]
public class MonsterScriptableObject : ScriptableObject {
    [SerializeField] private float health;
    [SerializeField] private float speed;
    [SerializeField] public float attackSpeed;
    [SerializeField] private float attackCoolDown;
    [SerializeField] private float damage;
    [SerializeField] private float stopDistance;

}
