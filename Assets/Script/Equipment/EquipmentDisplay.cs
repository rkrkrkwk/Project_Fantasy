using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDisplay : MonoBehaviour
{
    private Dictionary<EquipmentType, EquipmentHolder> itemHolderControl = new Dictionary<EquipmentType, EquipmentHolder>();
    [Serializable]
    private struct EquipmentHolderMapping
    {
        public EquipmentType type;
        public EquipmentHolder itemHolderControl;
    }
    [SerializeField]
    private EquipmentHolderMapping[] equipmentHolderMappings;

    void Start()
    {
        foreach (EquipmentHolderMapping mapping in equipmentHolderMappings)
        {
            itemHolderControl.Add(mapping.type, mapping.itemHolderControl);
        }
    }
    public void setEquipment(EquipmentType type, Item item)
    {
        itemHolderControl[type].SetItem(item);
    }
    public void Clear(EquipmentType type)
    {
        itemHolderControl[type].ClearItem();
    }
}
