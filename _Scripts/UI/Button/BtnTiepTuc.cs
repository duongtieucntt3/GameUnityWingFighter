using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnTiepTuc : BaseButton
{
    protected override void OnClick()
    {
        UIInventory.Instance.Close();
        Time.timeScale = 1f;
    }
}
