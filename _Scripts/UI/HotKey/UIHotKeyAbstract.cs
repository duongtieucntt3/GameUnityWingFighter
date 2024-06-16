using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyAbstract : DuongMonoBehaviour
{
    [SerializeField] protected UIHotKeyCtrl uIHotKeyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIHotKeyCtrl();
    }
    protected virtual void LoadUIHotKeyCtrl()
    {
        if (this.uIHotKeyCtrl != null) return;
        this.uIHotKeyCtrl = transform.parent.GetComponent<UIHotKeyCtrl>();
        Debug.Log(transform.name + ": LoadUIHotKeyCtrl", gameObject);
    }
}
