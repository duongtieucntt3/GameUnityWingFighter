using UnityEngine;

public abstract class BloodAbstract : DuongMonoBehaviour
{
    [Header("Bullet Abtract")]
    [SerializeField] protected ItemBloodCtrl itemBloodCtrl;
    public ItemBloodCtrl ItemBloodCtrl { get => itemBloodCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemCtrl();
    }

    protected virtual void LoadItemCtrl()
    {
        if (this.itemBloodCtrl != null) return;
        this.itemBloodCtrl = transform.parent.GetComponent<ItemBloodCtrl>();
        Debug.Log(transform.name + ": LoadItemBloodCtrl", gameObject);
    }
}
