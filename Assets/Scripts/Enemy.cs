using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float speed = 4f;
    [SerializeField] public float attackSpeed = 1;
    [SerializeField] private float attackCoolDown = 2f;
    [SerializeField] private float damage = 10f;
    [SerializeField] private float stopDistance = 1f;
    [SerializeField] private AudioSource audioSource;
    private Player _player;
    private float _attackTimer;

    [SerializeField] public GameObject enemyBody;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
        FollowPlayer();
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
}
