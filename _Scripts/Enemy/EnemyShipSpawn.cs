using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipSpawn : ShipManagerAbstact
{
    [Header("Enemy Ship Spawn")]
    [SerializeField] protected float timer = 0;
    [SerializeField] protected float delay = 0.3f;
    [SerializeField] protected int limit = 10;

    protected virtual void FixedUpdate()
    {
        this.Spawning();
        this.SetLimit();
        this.SetRandomLimitMotherShip();
        this.SetRandomLimitJunk();
    }

    protected virtual void Spawning()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        if (this.limit <= this.shipManagerCtrl.shipsManager.Ships.Count) return;
        this.timer = 0;

        ShipSpawnPos spawnPoint = this.GetSpawnPos();
        if (spawnPoint == null) return;
        Transform enemyObj;

        if (this.shipManagerCtrl.shipsManager.Ships.Count >= 20 && this.shipManagerCtrl.shipsManager.Ships.Count < 30) {
             enemyObj = EnemySpawner.Instance.Spawn(EnemySpawner.enemy_3, spawnPoint.transform.position, Quaternion.identity);
        }
        else if (this.shipManagerCtrl.shipsManager.Ships.Count >= 30)
        {
            enemyObj = EnemySpawner.Instance.Spawn(EnemySpawner.enemy_4, spawnPoint.transform.position, Quaternion.identity);
        }

        else
        {
            enemyObj = EnemySpawner.Instance.Spawn(EnemySpawner.enemy, spawnPoint.transform.position, Quaternion.identity);
        }


        EnemyCtrl enemyCtrl = enemyObj.GetComponent<EnemyCtrl>();
        this.shipManagerCtrl.shipsManager.AddShip(enemyCtrl);

        //ShipStandPos standPoint = this.GetStandPos(spawnPoint);//thay o day

        ShipStandPos standPoint;
        if ( this.shipManagerCtrl.shipsManager.Ships.Count > 10 && this.shipManagerCtrl.shipsManager.Ships.Count <= 20)
        {
            standPoint = GetStandPos_1(spawnPoint);
        }
        else if (this.shipManagerCtrl.shipsManager.Ships.Count > 20 && this.shipManagerCtrl.shipsManager.Ships.Count <= 30)
        {
            standPoint = GetStandPos_2(spawnPoint);
        }
        else if (this.shipManagerCtrl.shipsManager.Ships.Count > 30 && this.shipManagerCtrl.shipsManager.Ships.Count <= 36)
        {
            standPoint = GetStandPos_3(spawnPoint);
        }
        else
        {
            standPoint = GetStandPos(spawnPoint);
        }

        if (standPoint == null) return;

        enemyCtrl.gameObject.SetActive(true);
        ShipMoveFoward shipMoveFoward = enemyCtrl.ObjMovement as ShipMoveFoward;
        if (shipMoveFoward != null)
        {
            shipMoveFoward.SetMoveTarget(standPoint.transform);
            standPoint.SetAbilityObjectCtrl(enemyCtrl);
        }

    }

    protected virtual ShipStandPos GetStandPos(ShipSpawnPos spawnPos)
    {
        ShipStandPos standPos = null;

        List<ShipStandPos> positions = this.shipManagerCtrl.pointsManager.StandPoints;
        foreach (ShipStandPos shipStandPos in positions)
        {
            if (shipStandPos.IsOccupied()) continue;

            standPos = shipStandPos;
            break;
        }

        return standPos;
    }
    protected virtual ShipStandPos GetStandPos_1(ShipSpawnPos spawnPos)
    {
        ShipStandPos standPos = null;

        List<ShipStandPos> positions = this.shipManagerCtrl.pointsManager.StandPoints_1;
        foreach (ShipStandPos shipStandPos in positions)
        {
            if (shipStandPos.IsOccupied()) continue;

            standPos = shipStandPos;
            break;
        }

        return standPos;
    }

    protected virtual ShipStandPos GetStandPos_2(ShipSpawnPos spawnPos)
    {
        ShipStandPos standPos = null;

        List<ShipStandPos> positions = this.shipManagerCtrl.pointsManager.StandPoints_2;
        foreach (ShipStandPos shipStandPos in positions)
        {
            if (shipStandPos.IsOccupied()) continue;

            standPos = shipStandPos;
            break;
        }

        return standPos;
    }

    protected virtual ShipStandPos GetStandPos_3(ShipSpawnPos spawnPos)
    {
        ShipStandPos standPos = null;

        List<ShipStandPos> positions = this.shipManagerCtrl.pointsManager.StandPoints_3;
        foreach (ShipStandPos shipStandPos in positions)
        {
            if (shipStandPos.IsOccupied()) continue;

            standPos = shipStandPos;
            break;
        }

        return standPos;
    }

    protected virtual ShipSpawnPos GetSpawnPos()
    {
        ShipSpawnPos spawnPos = null;

        List<ShipSpawnPos> positions = this.shipManagerCtrl.pointsManager.SpawnPoints;
        foreach (ShipSpawnPos shipSpawnPos in positions)
        {
            if (shipSpawnPos.IsOccupied()) continue;

            spawnPos = shipSpawnPos;
            break;
        }

        return spawnPos;
    }

    protected virtual string GetEnemyName()
    {
        return "Enemy";
    }
    protected virtual void SetLimit()
    {
        if (this.shipManagerCtrl.shipsManager.Ships.Count == 10 && this.enemySpawner.SpawnedCount < 1)
        {
            this.limit += 10;
        }
        else if (this.shipManagerCtrl.shipsManager.Ships.Count == 20 && this.enemySpawner.SpawnedCount < 1)
        {
            this.limit += 10;
        }
        else if(this.shipManagerCtrl.shipsManager.Ships.Count == 30 && this.enemySpawner.SpawnedCount < 1)
        {
            this.limit += 6;
        }
    }
    protected virtual void SetRandomLimitMotherShip()
    {
        if (MotherShipSpawner.Instance.SpawnedCount == 1 )
        {
            MotherShipSpawner.Instance.SpawnerRandom.randomLimit = 0;
        }
        else if (this.shipManagerCtrl.shipsManager.Ships.Count == 36 && this.enemySpawner.SpawnedCount < 1 && !MotherShipSpawner.Instance.SpawnerRandom.isJunk)
        {
            MotherShipSpawner.Instance.SpawnerRandom.randomLimit = 1;
        }

    }
    protected virtual void SetRandomLimitJunk()
    {
        if (MotherShipSpawner.Instance.SpawnerRandom.isJunk && MotherShipSpawner.Instance.SpawnedCount == 0 && Enemy_2Spawner.Instance.SpawnedCount < 2)
        {
            JunkSpawnerRandom.instance.randomLimit = 6;
        }
    }

}
