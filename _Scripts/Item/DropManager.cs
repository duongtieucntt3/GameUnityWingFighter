using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : DuongMonoBehaviour
{
    private static DropManager instance;
    public static DropManager Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (DropManager.instance != null) Debug.LogError("Only 1 DropManager allow to exist");
        DropManager.instance = this;
    }

    public virtual void Drop(List<ItemDropRate> dropList)
    {
        Debug.Log(dropList[0].itemSO.itemName);
    }
}
