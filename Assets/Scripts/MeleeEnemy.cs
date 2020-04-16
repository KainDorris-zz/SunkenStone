using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    
    public override IEnumerator SpecialRoutine()
    {
        var originalDmg = damage;
        var originalColor = enemySprite.color;
        var originalSize = enemySprite.size;
        enemySprite.color = Color.red;
        damage = damage * 2f;
        
        float animationPercent = 0;
        while (animationPercent <= 5)
        {
            animationPercent += Time.deltaTime * attackSpeed;
            yield return null;
        }

        damage = originalDmg;
        enemySprite.color = originalColor;
    }
}
