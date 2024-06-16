using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2Despawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        Enemy_2Spawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 25f;
    }
}
