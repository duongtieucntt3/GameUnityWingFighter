using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnChienDich : BaseButton
{
    [SerializeField] protected Transform ChienDich;

    protected override void OnClick()
    {
        this.ChienDich.gameObject.SetActive(true);
    }
}
