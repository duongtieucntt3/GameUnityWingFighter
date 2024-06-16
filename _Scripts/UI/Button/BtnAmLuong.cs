using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnAmLuong : BaseButton
{
    [SerializeField] protected Transform AmLuong;

    protected override void OnClick()
    {
        this.AmLuong.gameObject.SetActive(true);
    }
}
