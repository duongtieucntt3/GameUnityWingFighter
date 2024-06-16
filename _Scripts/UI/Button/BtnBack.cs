using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBack : BaseButton
{
    protected override void OnClick()
    {
       // Debug.Log("OnClick Button Back");
        transform.parent.parent.gameObject.SetActive(false);
    }
}
