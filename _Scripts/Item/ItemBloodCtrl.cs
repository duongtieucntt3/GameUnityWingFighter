using Unity.VisualScripting;
using UnityEngine;

public class ItemBloodCtrl : ItemCtrl
{
    [SerializeField] protected DamageSenderBlood damageSenderBlood;
    public DamageSenderBlood DamageSenderBlood { get => damageSenderBlood; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSenderBlood();
    }

    protected virtual void LoadDamageSenderBlood()
    {
        if (this.damageSenderBlood != null) return;
        this.damageSenderBlood = transform.GetComponentInChildren<DamageSenderBlood>();
        Debug.Log(transform.name + ": LoadDamageSenderBlood", gameObject);
    }
}
