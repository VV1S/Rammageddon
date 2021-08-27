using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int dealedDamage = 1;
    [SerializeField] int currentHitPoints = 0;

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
        enemy.RewardGold();
    }

    void ProcessHit()
    {
        currentHitPoints -= dealedDamage;
    }

}
