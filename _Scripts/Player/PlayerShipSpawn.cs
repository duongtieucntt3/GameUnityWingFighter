using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipSpawn : ShipManagerAbstact
{

    protected override void Start()
    {
        base.Start();
        this.TestAddShips();
        Invoke(nameof(this.SpawnShips), 3);
    }

    protected virtual void TestAddShips()
    {
        Transform shipObj;
        ShipCtrl shipCtrl;

        shipObj = ShipsSpawner.Instance.Spawn(ShipCode.Fighter);
        shipCtrl = shipObj.GetComponent<ShipCtrl>();
        this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);

        //shipObj = ShipsSpawner.Instance.Spawn(ShipCode.Healer);
        //shipCtrl = shipObj.GetComponent<PlayerShipCtrl>();
        //this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);

        //shipObj = ShipsSpawner.Instance.Spawn(ShipCode.Tanker);
        //shipCtrl = shipObj.GetComponent<PlayerShipCtrl>();
        //this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);

        //shipObj = ShipsSpawner.Instance.Spawn(ShipCode.Miner);
        //shipCtrl = shipObj.GetComponent<PlayerShipCtrl>();
        //this.shipManagerCtrl.shipsManager.AddShip(shipCtrl);
    }

    public virtual void SpawnShips()
    {
        Debug.Log("SpawnShips");

        int index = 0;
        foreach (ShipCtrl shipCtrl in this.shipManagerCtrl.shipsManager.Ships)
        {
            this.SpawnShip(shipCtrl, index);
            index++;
        }
    }

    protected virtual void SpawnShip(ShipCtrl shipCtrl, int index)
    {
        ShipMoveFoward shipMoveFoward;

        Transform spawnPoint = this.shipManagerCtrl.pointsManager.SpawnPoints[index].transform;
        shipCtrl.transform.position = spawnPoint.position;
        shipCtrl.gameObject.SetActive(true);

        ShipStandPos standPoint = this.shipManagerCtrl.pointsManager.StandPoints[index];
        shipMoveFoward = shipCtrl.ObjMovement as ShipMoveFoward;
        if (shipMoveFoward != null)
        {
            shipMoveFoward.SetMoveTarget(standPoint.transform);
            standPoint.SetAbilityObjectCtrl(shipCtrl);
        }
    }
}
