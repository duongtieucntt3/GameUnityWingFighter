
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHpPlayer : BaseSlider
{
    [SerializeField] protected float maxHP = 100;
    [SerializeField] protected float currentHP = 100;


    protected override void FixedUpdate()
    {
        this.HPShowing();
    }
    protected override void OnChanged(float newValeu)
    {
        //Debug.Log(" onChanged" + newValeu);
    }
    public virtual void SetMaxHp(float maxHP)
    {
        this.maxHP = maxHP;
    }
    public virtual void SetCurrentHp(float currentHP)
    {
        this.currentHP = currentHP;
    }
    protected virtual void HPShowing()
    {
        if (PlayerCtrl.Instance.CurrentShip == null) return;
        float hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.Hp;
        float hpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HpMax;
        this.SetMaxHp(hpMax);
        this.SetCurrentHp(hp);
        float hpPercent = this.currentHP / this.maxHP;
        this.slider.value = hpPercent;

    }
}
