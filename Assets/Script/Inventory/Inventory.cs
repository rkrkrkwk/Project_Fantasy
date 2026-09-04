using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private PlayerStatusManager playerStatusManager;
    public struct InventoryItem
    {
        public int itemID;
        public int quantity;

        public InventoryItem(int id, int qty)
        {
            itemID = id;
            quantity = qty;
        }
    }
    private List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public List<InventoryItem> InventoryItems => inventoryItems;

    private void Start()
    {
        InitializeInventory();
    }

    public void InitializeInventory()
    {
        for (int i = 0; i < playerStatusManager.Inv; i++)
        {
            inventoryItems.Add(new InventoryItem(-1, 1));
        }
    }

    public void AddItem(int itemID, int quantity)
    {
        int index = -1;
        for(int i=0; i<playerStatusManager.Inv; i++)
        {
            if (inventoryItems[i].itemID == itemID)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            inventoryItems[index] = new InventoryItem(itemID, inventoryItems[index].quantity + quantity);
        }
        else
        {
            for (int i = 0; i < playerStatusManager.Inv; i++)
            {
                if (inventoryItems[i].itemID == -1)
                {
                    inventoryItems[i] = new InventoryItem(itemID, quantity);
                    return;
                }
            }
            Debug.LogWarning("Inventory is full. Cannot add more items.");
        }
        // debug in inventory
        foreach (var item in inventoryItems)
        {
            Debug.Log($"Item ID: {item.itemID}, Quantity: {item.quantity}");
        }
    }

    public void RemoveItem(int itemID, int quantity)
    {
        int index = -1;
        for (int i = 0; i < playerStatusManager.Inv; i++)
        {
            if (inventoryItems[i].itemID == itemID)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            int newQuantity = inventoryItems[index].quantity - quantity;
            if (newQuantity > 0)
            {
                inventoryItems[index] = new InventoryItem(itemID, newQuantity);
            }
            else
            {
                inventoryItems[index] = new InventoryItem(-1, 1);
            }
        }
        else
        {
            Debug.LogWarning("Item not found in inventory.");
        }
    }
}
