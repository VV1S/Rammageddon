using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem ProjectileParticles;
    [SerializeField] Transform weapon;
    Transform target;


    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance<maxDistance)
            {
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = closestTarget;
    }

    void AimWeapon()
    {
        if(target==null)
        {
            Attack(false);
        }
        else
        {
            float targetDistance = Vector3.Distance(transform.position, target.position);
            weapon.LookAt(target);

            if(targetDistance<range)
            {
                Attack(true);
            }
            else
            {
                Attack(false);
            }
        }

    }

    void Attack(bool isActive)
    {
        var emissionModule = ProjectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
