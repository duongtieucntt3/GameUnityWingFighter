using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : DuongMonoBehaviour
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHp sliderHp;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;

    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHp();
        this.LoadFollowTarget();
        this.LoadSpawner();

    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
        Debug.Log(transform.name + ": LoadFollowTarget", gameObject);
    }
    protected virtual void LoadSliderHp()
    {
        if (this.sliderHp != null) return;
        this.sliderHp = transform.GetComponentInChildren<SliderHp>();
        Debug.Log(transform.name + ": LoadSliderHp", gameObject);
    }
    protected virtual void HPShowing()
    {

        if(this.shootableObjectCtrl == null) return;
        if (this.shootableObjectCtrl.DamageReceiver.IsDead())
        {
            this.spawner.Despawn(transform);
            return;
        }
        float hp = this.shootableObjectCtrl.DamageReceiver.Hp;
        float hpMax = this.shootableObjectCtrl.DamageReceiver.HpMax;
        this.sliderHp.SetMaxHp(hpMax);
        this.sliderHp.SetCurrentHp(hp);
       
    }
   public virtual void SetObjectCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }
    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
}
