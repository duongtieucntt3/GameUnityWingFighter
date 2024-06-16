using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapLevel : LevelByDistance
{
    //[Header("Map")]

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.MapSetTartet();
    }

    protected virtual void MapSetTartet()
    {
 
        if (this.target != null) return;
        if (PlayerCtrl.Instance.CurrentShip == null) return;
        ShipCtrl currentShip = PlayerCtrl.Instance.CurrentShip;
        this.SetTarget(currentShip.transform);
    }
}

