using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] GameObject projectile;
    private Vector3 playerPos; 

    

    
    public override IEnumerator AttackRoutine()
    {
        
        float animationPercent = 0;
        gameObject.GetComponent<AudioSource>().Play();
        Shoot();
        while (animationPercent <= 1)
        {
            animationPercent += Time.deltaTime * gameObject.GetComponent<Enemy>().attackSpeed;
            // Trigger Animation here.
            yield return null;
        }
        gameObject.GetComponent<AudioSource>().Stop();
    }

    public override IEnumerator SpecialRoutine()
    {
        for (var i = 0; i < 3; i++)
        {
            float animationPercent = 0;
            gameObject.GetComponent<AudioSource>().Play();

            Shoot();
            
            while (animationPercent <= 1)
            {
                animationPercent += Time.deltaTime * gameObject.GetComponent<Enemy>().attackSpeed;
                // Trigger Animation here.
                yield return null;
            }
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }

    private void Shoot(){
            playerPos = GetPlayerPosition();
            
            Vector3 lookDir = enemyBody.transform.position - playerPos;
            
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
            
            Vector3 angleVector = new Vector3(0f, 0f, angle);
            
            enemyBody.GetComponent<Transform>().rotation = Quaternion.Euler(angleVector);
            
            Instantiate(projectile, transform.position, enemyBody.transform.rotation, gameObject.transform);
    }
}
