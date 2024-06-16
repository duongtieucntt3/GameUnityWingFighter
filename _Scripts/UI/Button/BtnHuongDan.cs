using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnHuongDan : BaseButton
{
    [SerializeField] protected Transform HuongDan;

    protected override void OnClick()
    {
     //   Debug.Log("OnClick Button HuongDan");
        this.HuongDan.gameObject.SetActive(true);
    }
}
