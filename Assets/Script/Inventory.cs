using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    private InventoryDisplay inventoryDisplay;
    public struct itemSlot
    {
        public int id;
        public int quantity;
    }
    private List<itemSlot> invenList = new List<itemSlot>();
    public IReadOnlyList<itemSlot> InvenList => invenList;
    private int gold = 0;
    public int Gold => gold;
    public void AddItem(int id, int count)
    {
        int idx = invenList.FindIndex(x => x.id == id);
        if (idx == -1)
        {
            invenList.Add(new itemSlot { id = id, quantity = count });
        }
        else
        {
            int temp = invenList[idx].quantity + count;
            invenList[idx] = new itemSlot { id = id, quantity = temp };
        }
        inventoryDisplay.DisplayItem();
    }
    public void RemoveItem(int id, int count)
    {
        int idx = invenList.FindIndex(x => x.id == id);
        if (idx == -1) return;
        int temp = invenList[idx].quantity - count;
        if (temp <= 0)
            invenList.RemoveAt(idx);
        else
        {
            invenList[idx] = new itemSlot { id = id, quantity = temp };
        }
        inventoryDisplay.DisplayItem();
    }
    public void AddGold(int amount)
    {
        gold += amount;
        inventoryDisplay.DisplayGold();
    }
    public void RemoveGold(int amount)
    {
        gold -= amount;
        if (gold < 0) gold = 0;
        inventoryDisplay.DisplayGold();
    }
}
