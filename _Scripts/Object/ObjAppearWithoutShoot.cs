using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearWithoutShoot : ShootableObjectAbstract, IObjAppearObserver // IObjAppearObserver  để có interface 
{
    [Header("Without Shoot")]

    [SerializeField] protected ObjAppearing objAppearing;
    

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RigisterAppearEvent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjAppearing();

    }
    protected virtual void LoadObjAppearing()
    {
        if (this.objAppearing != null) return;
        this.objAppearing = transform.GetComponent<ObjAppearing>();
        Debug.LogWarning(transform.name + ": LoadObjAppearing", gameObject);
    }
    protected virtual void RigisterAppearEvent()
    {
        this.objAppearing.ObserverAdd(this);// muốn chính class này nó lắng nghe dc sự kiện bên observer
    }

    public void OnAppearStart()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(false);
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(false);
        //đây là hàm xảy ra thì class, script này làm gì.
    }

    public void OnAppearFinish()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(true);
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(true);

        this.shootableObjectCtrl.Spawner.Hold(transform.parent);
        //đây là hàm kết thúc thì class, script này làm gì.
    }
}
