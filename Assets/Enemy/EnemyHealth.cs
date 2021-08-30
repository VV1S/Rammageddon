using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;

    [Tooltip("Adds amount to maxHitpoints when enemy dies.")]
    [SerializeField] int difficultyRamp = 1;
    
    int dealedDamage = 1;    
    int currentHitPoints = 0;

    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(currentHitPoints<1)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        gameObject.SetActive(false);
        maxHitPoints += difficultyRamp;
        enemy.RewardGold();
    }

    void ProcessHit()
    {
        currentHitPoints -= dealedDamage;
    }

}
