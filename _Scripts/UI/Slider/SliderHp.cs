using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHp : BaseSlider
{
    [SerializeField] protected float maxHP = 100;
    [SerializeField] protected float currentHP = 70;


    protected override void FixedUpdate()
    {
        this.HPShowing();
    }
    protected virtual void HPShowing()
    {
        float hpPercent = this.currentHP / this.maxHP;
        this.slider.value = hpPercent;
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
        this.currentHP=currentHP;
    }
}
