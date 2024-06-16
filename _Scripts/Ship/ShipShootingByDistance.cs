using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShipShootingByDistance : ObjShooting
{
    [Header("Shoot by Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance= Mathf.Infinity;
    [SerializeField] protected float ShootDistance= 3f;

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(transform.position, target.position);
        this.isShooting = this.distance < this.ShootDistance;
        return this.isShooting;
    }
}
