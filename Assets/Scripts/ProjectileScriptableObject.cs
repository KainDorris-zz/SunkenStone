using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ProjectileScriptableObject", menuName = "SunkenStone/Projectiles/ProjectileScriptableObject", order = 0)]
public class ProjectileScriptableObject : ScriptableObject {
    //todo: wiring
    [SerializeField] public float projectileForce;
    [SerializeField] public float projectileDamage;
    [SerializeField, Range(1f, 10f)] public float criticalMultiplier = 1f;
    [SerializeField, Range(1f, 10f)] public float weaknessMultiplier = 0.5f; 
    [SerializeField] public float enemyProjectileForce;
    [SerializeField] public float enemyProjectileDamage;
    [SerializeField] public Sprite projectileSprite;
    [SerializeField] public DamageType damageTypes;
    [SerializeField] public AudioClip damageSound;
    [SerializeField] public AudioClip criticalSound;
    [SerializeField] public AudioClip weakSound;
    

}
