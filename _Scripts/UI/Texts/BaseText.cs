using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseText : DuongMonoBehaviour
{
    [Header("Base Text")]
    [SerializeField] protected TextMeshProUGUI textMeshPro;

    protected override void Start()
    {
        base.Start();
        
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }
    protected virtual void LoadText()
    {
        if (this.textMeshPro != null) return;
        this.textMeshPro = GetComponent<TextMeshProUGUI>();
        Debug.LogWarning(transform.name + ": LoadText", gameObject);
    }

}
