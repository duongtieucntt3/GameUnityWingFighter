using UnityEngine;

public abstract class ShipManagerAbstact : DuongMonoBehaviour
{
    [Header("Ship Manager Abstact")]
    public ShipManagerCtrl shipManagerCtrl;
    public EnemySpawner enemySpawner;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipManagerCtrl();
    }

    protected virtual void LoadShipManagerCtrl()
    {
        if (this.shipManagerCtrl != null) return;
        this.shipManagerCtrl = transform.parent.GetComponent<ShipManagerCtrl>();
        Debug.LogWarning(transform.name + ": LoadShipManagerCtrl", gameObject);
    }

}
