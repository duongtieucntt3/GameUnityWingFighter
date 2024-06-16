using UnityEngine;

public class EnemyCtrl : AbilityObjectCtrl
{

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }


}
