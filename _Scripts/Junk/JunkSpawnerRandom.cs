using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : DuongMonoBehaviour
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;

    [SerializeField] protected AudioSource AudioChienThang;

    public static JunkSpawnerRandom instance;

    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] public int randomLimit = 0;

    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawnerRandom.instance != null) Debug.LogError("Only 1 JunkSpawnerRandom allow to exist");
        JunkSpawnerRandom.instance = this;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkSpawnerCtrl != null) return;
        this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }


    protected override void Start()
    {
        //this.JunkSpawning();
    }
    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected virtual void SetRandomDelay()
    {
        this.randomDelay = 50f;
        Invoke("SetGameVictory", 7f);
    }
    protected virtual void SetGameVictory()
    {
        this.AudioChienThang.Play();
        UIInventory.Instance.Open();
        UIInventory.Instance.BtnTiepTuc.gameObject.SetActive(false);
        UIInventory.Instance.GameVictory.gameObject.SetActive(true);
        UIInventory.Instance.BtnBtnInvClose.gameObject.SetActive(false);
        Time.timeScale = 0f;
    }
    protected virtual void JunkSpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;


        Transform ranPoint = this.junkSpawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;
        Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefab();
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);

        //Invoke(nameof(this.JunkSpawning), 7f);
        Invoke("SetRandomDelay", 20f);
    }
    protected virtual bool RandomReachLimit()
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= this.randomLimit;
    }

}
