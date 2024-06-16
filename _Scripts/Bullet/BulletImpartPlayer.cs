
using UnityEngine;

public class BulletImpartPlayer : BulletImpart
{

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.transform.parent == this.bulletCtrl.Shooter) return;
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            this.bulletCtrl.DamageSender.Send(other.transform);
        }
    }
}

