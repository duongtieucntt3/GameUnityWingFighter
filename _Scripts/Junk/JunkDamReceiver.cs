using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkCtrl junkCtrl;
    [SerializeField] protected AudioSource AudioJunkExplode;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": LoadJunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFx();
        this.AudioJunkExplode.Play();
        this.OnDeadDrop();
        this.junkCtrl.JunkDespawn.DespawnObject();
       
    }
    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList, dropPos, dropRot);
    }
    protected virtual void OnDeadFx()
    {
        string fxName= this.GetOnDeadFxName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFxName()
    {
        return FXSpawner.Smoke1;
    }
    public override void Reborn()
    {
        this.hpMax = this.junkCtrl.ShootableObject.hpMax;
        base.Reborn();
    }
}
