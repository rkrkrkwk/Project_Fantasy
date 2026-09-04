using System;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private Dictionary<EquipmentType, Item> items = new Dictionary<EquipmentType, Item>();
    public IReadOnlyDictionary<EquipmentType, Item> Items => items;
    void Awake()
    {
        foreach (EquipmentType type in Enum.GetValues(typeof(EquipmentType)))
        {
            items.Add(type, null);
        }
    }
    public void SetItem(EquipmentType part, Item item)
    {
        items[part] = item;
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