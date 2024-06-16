using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : DuongMonoBehaviour
{
    [Header("UI Item Inventory")]
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected TextMeshProUGUI itemName;
    public TextMeshProUGUI ItemName => itemName;

    [SerializeField] protected TextMeshProUGUI itemNumber;
    public TextMeshProUGUI ItemNumber => itemNumber;

    [SerializeField] protected Image itemSprite;
    public Image ItemSprite => itemSprite;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumber();
        this.LoadItemSprite();
    }
    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }
    protected virtual void LoadItemNumber()
    {
        if (this.itemNumber != null) return;
        this.itemNumber = transform.Find("ItemNumber").GetComponent<TextMeshProUGUI>();
        Debug.Log(transform.name + ": LoadItemNumber", gameObject);
    }
    protected virtual void LoadItemSprite()
    {
        if (this.itemSprite != null) return;
        this.itemSprite = transform.Find("ItemSprite").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemSprite", gameObject);
    }
    public virtual void ShowItem(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.text = item.itemProfile.itemName;
        this.itemNumber.text = item.itemCount.ToString();
        this.itemSprite.sprite = item.itemProfile.sprite;
    }
}