using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDisplay : MonoBehaviour
{
    [SerializeField]
    private Equipment equipment;
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
    void OnEnable()
    {
        DisplayEquipment();
    }
    public void DisplayEquipment()
    {
        foreach (var pair in itemHolderControl)
        {
            if (equipment.Items[pair.Key] != null)
                pair.Value.SetItem(equipment.Items[pair.Key]);
            else
                pair.Value.ClearItem();
        }
    }
}
