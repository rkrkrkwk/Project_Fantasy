using System;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private List<int> EquipmentList = new List<int>();
    public List<int> GetEquipmentList() => EquipmentList;
    private Dictionary<EquipmentType, Item> items = new Dictionary<EquipmentType, Item>();
    public IReadOnlyDictionary<EquipmentType, Item> Items => items;
    void Awake()
    {
        foreach (EquipmentType type in Enum.GetValues(typeof(EquipmentType)))
        {
            EquipmentList.Add(0);
            items.Add(type, null);
        }
    }
    public void SetItem(EquipmentType part, Item item)
    {
        EquipmentList[(int)part] = item.id;
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