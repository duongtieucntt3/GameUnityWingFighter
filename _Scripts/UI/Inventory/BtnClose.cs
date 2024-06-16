using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnClose : BaseButton
{
    protected override void OnClick()
    {
        UIInventory.Instance.Close();
    }
}
