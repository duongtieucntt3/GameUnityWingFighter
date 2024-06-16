using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class UIInventoryAbstract : DuongMonoBehaviour
{
    [Header("Inventory Abstract")]
    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryCtrl();
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.uIInventoryCtrl != null) return;
        this.uIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        Debug.Log(transform.name + ": LoadUIInventoryCtrl", gameObject);
    }


}