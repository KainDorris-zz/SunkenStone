﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "ProjectileScriptableObject", menuName = "SunkenStone/Projectiles/ProjectileScriptableObject", order = 0)]
public class ProjectileScriptableObject : ScriptableObject {
    //todo: wiring
    [SerializeField] public float projectileForce;
    [SerializeField] public float projectileDamage; 
    [SerializeField] public float enemyProjectileForce;
    [SerializeField] public float enemyProjectileDamage;
    [SerializeField] public Sprite projectileSprite;
    [SerializeField] public DamageType damageTypes;
    [SerializeField] public AudioClip damageSound;
    [SerializeField] public AudioClip criticalSound;
    [SerializeField] public AudioClip weakSound;

}
