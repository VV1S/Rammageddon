using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [SerializeField] int dealedDamage = 1;
    [SerializeField] int currentHitPoints = 0;

    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
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
    }

    void ProcessHit()
    {
        currentHitPoints -= dealedDamage;
    }

}
