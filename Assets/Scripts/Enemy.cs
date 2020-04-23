using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class Enemy : MonoBehaviour
{   
    [SerializeField] public MonsterScriptableObject enemyData;
    [SerializeField] private ResourceManager _resourceManager;
    private float health;
    private float speed;
    public float attackSpeed;
    private float attackCoolDown;
    public float damage;
    private float stopDistance;
    private List<DamageType> weaknesses;
    private List<DamageType> resistances;
    [SerializeField] public AudioSource audioSource;
    public Player _player;


    public SpriteRenderer enemySprite;
    private float _attackTimer;
    private Random _dice = new Random();

    [SerializeField] public GameObject enemyBody;

    private void Start()
    {
        
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        _resourceManager = GameObject.Find("Canvas").GetComponent<ResourceManager>();
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
                    // on percentage
                    if (_dice.Next(1, 7) > 5)
                    {
                       StartCoroutine(SpecialRoutine()); 
                    }
                    else
                    {
                       StartCoroutine(AttackRoutine()); 
                    }
                    
                    
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
        enemySprite.sprite = enemyData.sprite;
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
    
    public virtual IEnumerator SpecialRoutine()
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
            _resourceManager.AddResource(); // TODO: Move this when we add in environmental hazards.
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
