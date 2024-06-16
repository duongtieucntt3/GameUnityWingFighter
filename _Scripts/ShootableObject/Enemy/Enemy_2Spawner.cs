using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_2Spawner : Spawner
{
    private static Enemy_2Spawner instance;
    public static Enemy_2Spawner Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (Enemy_2Spawner.instance != null) Debug.LogError("Only 1 Enemy_2Spawner allow to exist");
        Enemy_2Spawner.instance = this;
    }

    public override Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab, spawnPos, rotation);
        this.AddHPBar2Obj(newEnemy);
        return newEnemy;
    }

    protected virtual void AddHPBar2Obj(Transform newEnemy)
    {
        ShootableObjectCtrl newEnemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar, newEnemy.position, Quaternion.identity);
        HPBar hpBar = newHpBar.GetComponent<HPBar>();
        hpBar.SetObjectCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);

        newHpBar.gameObject.SetActive(true);
    }
}
