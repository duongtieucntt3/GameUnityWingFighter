using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    public Transform BtnTiepTuc;
    public Transform GameOver;
    public Transform GameVictory;
    public Transform BtnBtnInvClose;


    protected bool isOpen = false;

    [SerializeField] protected InventorySort inventorySort;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }
    protected override void Start()
    {
        base.Start();
        this.Close();
        // InvokeRepeating(nameof(this.ShowItems), 1, 1);
    }
    protected void Update()
    {
        this.ShowItems();
    }
    protected virtual void FixedUpdate()
    {
        //
    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if(this.isOpen ) this.Open();
        else this.Close();
    }
    public virtual void Close()
    {
        this.UIInventoryCtrl.gameObject.SetActive(false);
        this.isOpen=false;
    }
    public virtual void Open()
    {
        this.UIInventoryCtrl.gameObject.SetActive(true);
        this.isOpen=true;
    }
    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;

        this.ClearItems();

        List<ItemInventory> items = PlayerCtrl.Instance.CurrentShip.Inventory.Items;
        UIInvItemSpawner spawner = this.UIInventoryCtrl.UIInvItemSpawner;

        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }

        this.SortItems();
    }

    protected virtual void ClearItems()
    {
        this.UIInventoryCtrl.UIInvItemSpawner.ClearItems();
    }

    protected virtual void SortItems()
    {
        if (this.inventorySort == InventorySort.NoSort) return;

        Debug.Log("== InventorySort.ByName ====");

        int itemCount = this.UIInventoryCtrl.Content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        ItemProfileSO currentProfile, nextProfile;
        string currentName, nextName;
        int currentCount, nextCount;

        bool isSorting = false;
        for (int i = 0; i < itemCount - 1; i++)
        {
            currentItem = this.UIInventoryCtrl.Content.GetChild(i);
            nextItem = this.UIInventoryCtrl.Content.GetChild(i + 1);

            currentUIItem = currentItem.GetComponent<UIItemInventory>();
            nextUIItem = nextItem.GetComponent<UIItemInventory>();

            currentProfile = currentUIItem.ItemInventory.itemProfile;
            nextProfile = nextUIItem.ItemInventory.itemProfile;

            bool isSwap = false;

            switch (this.inventorySort)
            {
                case InventorySort.ByName:
                    currentName = currentProfile.itemName;
                    nextName = nextProfile.itemName;
                    isSwap = string.Compare(currentName, nextName) == 1;
                    break;
                case InventorySort.ByCount:
                    currentCount = currentUIItem.ItemInventory.itemCount;
                    nextCount = nextUIItem.ItemInventory.itemCount;
                    isSwap = currentCount > nextCount;
                    break;
            }

            if (isSwap)
            {
                this.SwapItems(currentItem, nextItem);
                isSorting = true;
            }
        }

        if (isSorting) this.SortItems();
    }


    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }


}