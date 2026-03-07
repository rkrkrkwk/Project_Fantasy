using System;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private Inventory inventory;
    private Dictionary<EquipmentType, Item> items = new Dictionary<EquipmentType, Item>();
    public IReadOnlyDictionary<EquipmentType, Item> Items => items;
    [SerializeField]
    private EquipmentDisplay equipmentDisplay;
    [SerializeField]
    private Status status;
    void Awake()
    {
        inventory = GetComponent<Inventory>();
        foreach (EquipmentType type in Enum.GetValues(typeof(EquipmentType)))
        {
            items.Add(type, null);
        }
    }
    public void Equip(EquipmentType part, Item item)
    {
        if(IsEquipped(part))
        {
            Unequip(part);
        }
        SetItem(part, item);
        status.resetStatus();
        equipmentDisplay.DisplayEquipment();
        inventory.RemoveItem(item.id, 1);
    }
    public void Unequip(EquipmentType part)
    {
        inventory.AddItem(GetItem(part).id, 1);
        RemoveItem(part);
        status.resetStatus();
        equipmentDisplay.DisplayEquipment();
    }
    public void SwitchEquipment(EquipmentType part, EquipmentType targetPart)
    {
        Item temp = GetItem(part);
        SetItem(part, GetItem(targetPart));
        SetItem(targetPart, temp);
        equipmentDisplay.DisplayEquipment();
    }
    public void SetItem(EquipmentType part, Item item)
    {
        items[part] = item;
    }
    public void RemoveItem(EquipmentType part)
    {
        items[part] = null;
    }
    public Item GetItem(EquipmentType part)
    {
        return items[part];
    }
    public bool IsEquipped(EquipmentType part)
    {
        return items[part] != null;
    }
}