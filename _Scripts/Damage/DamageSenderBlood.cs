using UnityEngine;

public class DamageSenderBlood : DuongMonoBehaviour
{
    [SerializeField] protected int amount = 10;

    public virtual void Send_Blood(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send_Blood(damageReceiver);
    }
    public virtual void Send_Blood(DamageReceiver damageReceiver)
    {
        damageReceiver.Add(this.amount);

    }
}
