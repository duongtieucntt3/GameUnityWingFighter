using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnInven : BaseButton
{
    protected override void OnClick()
    {
        UIInventory.Instance.Toggle();
    }
}
