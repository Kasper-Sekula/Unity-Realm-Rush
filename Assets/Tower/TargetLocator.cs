using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    void AimWeapon()
    {
        if (target != null){
            var pos = target.position;
            pos = new Vector3(pos.x, 2f, pos.z);
            weapon.LookAt(pos);
        } else {
            ParticleSystem particleSys =  this.gameObject.GetComponentInChildren<ParticleSystem>();
            var em = particleSys.emission;
            em.enabled = false;
        }
    }
}
