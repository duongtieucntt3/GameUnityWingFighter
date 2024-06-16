using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipHP : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHP();

    }
    protected virtual void UpdateShipHP()
    {
        if (PlayerCtrl.Instance.CurrentShip == null) return;
        int HpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.HpMax;
        int Hp = PlayerCtrl.Instance.CurrentShip.DamageReceiver.Hp;
        this.textMeshPro.SetText(Hp + "/" + HpMax);
    }
}
