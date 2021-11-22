using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] int range = 50;
    Transform target;


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

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance){
                closestTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        if (target != null){
            var pos = target.position;
            pos = new Vector3(pos.x, 2f, pos.z);
            weapon.LookAt(pos);

            if(targetDistance < range){
                Attack(true);
            } else {
                Attack(false);
            }
        } else {
            ParticleSystem particleSys =  this.gameObject.GetComponentInChildren<ParticleSystem>();
            var em = particleSys.emission;
            em.enabled = false;
        }
    }

    void Attack(bool isActive){
        var emissionModule= projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
