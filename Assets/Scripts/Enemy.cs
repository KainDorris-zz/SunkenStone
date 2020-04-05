using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    [SerializeField] public MonsterScriptableObject enemyData;
    private float health;
    private float speed;
    public float attackSpeed;
    private float attackCoolDown;
    private float damage;
    private float stopDistance;
    private List<DamageType> weaknesses;
    private List<DamageType> resistances;
    [SerializeField] private AudioSource audioSource;
    private Player _player;
    

    private SpriteRenderer enemySprite;
    private float _attackTimer;

    [SerializeField] public GameObject enemyBody;

    private void Start()
    {
        
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        enemySprite = gameObject.GetComponent<SpriteRenderer>();
        Setup();
    }

    private void Update()
    {
        FollowPlayer();
        Flip();
    }

    private void FollowPlayer()
    {
        if (_player != null)
        {
            Vector3 playerTransform = _player.transform.position;
            if (Vector3.Distance(transform.position, playerTransform) > stopDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    playerTransform, speed * Time.deltaTime);
            }
            else
            {
                if (Time.time >= _attackTimer)
                {
                    StartCoroutine(AttackRoutine());
                    _attackTimer = Time.time + attackCoolDown;
                }
            }
        }
    }

    private void Flip(){

        if(transform.position.x < _player.transform.position.x){
            enemySprite.flipX = false;
        }else{
            enemySprite.flipX = true;
        }
    }

    private void Setup(){
        
        health = enemyData.health;
        speed = enemyData.speed;
        attackSpeed = enemyData.attackSpeed;
        attackCoolDown = enemyData.attackCoolDown;
        damage = enemyData.damage;
        stopDistance = enemyData.stopDistance;
        enemySprite.sprite = enemyData.enemySprite;
        weaknesses = enemyData.weaknesses;
        resistances = enemyData.resistances;
        
    }

    public virtual IEnumerator AttackRoutine()
    {
        float animationPercent = 0;
        audioSource.Play();
        _player.TakeDamage(damage);
        while (animationPercent <= 1)
        {
            animationPercent += Time.deltaTime * attackSpeed;
            // Trigger Animation here.
            yield return null;
        }
        audioSource.Stop();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public float GetCurrentHealth(){
        return health;
    }

    public Vector3 GetPlayerPosition(){
        return _player.transform.position;
    }

    public List<DamageType> GetResistances(){
        return resistances;
    }

    public List<DamageType> GetWeaknesses(){
        return weaknesses;
    }
}
