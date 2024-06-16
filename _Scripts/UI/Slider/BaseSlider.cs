using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : DuongMonoBehaviour
{
    [Header("Base Slider")]
    [SerializeField] protected Slider slider;

    protected override void Start()
    {
        base.Start();
        this.OnValueChanged();
    }

    protected virtual void FixedUpdate()
    {
        
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
        Debug.LogWarning(transform.name + ": LoadSlider", gameObject);
    }
    protected virtual void OnValueChanged()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }
    protected abstract void OnChanged(float newValeu);

}
