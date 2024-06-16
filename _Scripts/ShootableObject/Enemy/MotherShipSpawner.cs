using UnityEngine;

public class MotherShipSpawner : Spawner
{
    private static MotherShipSpawner instance;
    public static MotherShipSpawner Instance => instance;

    [SerializeField] protected SpawnerRandom spawnerRandom;
    public SpawnerRandom SpawnerRandom => spawnerRandom;
    protected override void Awake()
    {
        base.Awake();
        if (MotherShipSpawner.instance != null) Debug.LogError("Only 1 MotherShipSpawner allow to exist");
        MotherShipSpawner.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerRandom();
    }
    protected virtual void LoadSpawnerRandom()
    {
        if (this.spawnerRandom != null) return;
        this.spawnerRandom = GetComponent<SpawnerRandom>();
        Debug.LogWarning(transform.name + "LoadSpawnerRandom", gameObject);
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
        Transform newHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBarMotherShip, newEnemy.position, Quaternion.identity);
        HPBar hpBar = newHpBar.GetComponent<HPBar>();
        hpBar.SetObjectCtrl(newEnemyCtrl);
        hpBar.SetFollowTarget(newEnemy);

        newHpBar.gameObject.SetActive(true);
    }
}
