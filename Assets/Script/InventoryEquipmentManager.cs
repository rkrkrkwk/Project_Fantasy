using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryEquipmentManager : MonoBehaviour
{
    [SerializeField] private EquipmentManager equipmentManager;
    [SerializeField] private Inventory inventory;
    [SerializeField] private InventoryDisplay inventoryDisplay;
    private int selectedIndex=-1;
    public static InventoryEquipmentManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetIndex(int index)
    {
        selectedIndex = index;
    }
    public int getIndex()
    {
        return selectedIndex;
    }
    public void DoEquip(EquipmentType type)
    {
        int itemID = inventory.InventoryItems[selectedIndex].itemID;
        equipmentManager.Equip(type, ItemList.Instance.GetItem(itemID));
        inventory.RemoveItem(itemID, 1);
        inventoryDisplay.Refresh();
    }
    public void DoUnequip(EquipmentType type, int itemID)
    {
        equipmentManager.Unequip(type);
        inventory.AddItem(ItemList.Instance.GetItem(itemID).id, 1);
        inventoryDisplay.Refresh();
    }
}
