using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy : AbilitySummon
{
    [Header("Summon Enemy")]
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int minionLimit = 10;


    protected override void Start()
    {
        InvokeRepeating(nameof(this.ClearDeadMinions), 2f, 0.02f);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemy_2Spawner();
    }

    protected virtual void LoadEnemy_2Spawner()
    {
        if (this.spawner != null) return;
        GameObject enemy_2Spawner = GameObject.Find("Enemy_2Spawner");
        this.spawner = enemy_2Spawner.GetComponent<Enemy_2Spawner>();
        Debug.LogWarning(transform.name + ": LoadAbilities", gameObject);
    }

    protected override void Summoning()
    {
        if (this.minions.Count >= this.minionLimit) return;
        base.Summoning();
    }

    protected override Transform Summon()
    {
        Transform minion = base.Summon();
        minion.parent = this.abilities.AbilityObjectCtrl.transform;
        this.minions.Add(minion);
        return minion;
    }

    protected virtual void ClearDeadMinions()
    {
        foreach (Transform minion in this.minions)
        {
            if (minion.gameObject.activeSelf == false)
            {
                this.minions.Remove(minion);
                return;
            }
        }
    }
}
