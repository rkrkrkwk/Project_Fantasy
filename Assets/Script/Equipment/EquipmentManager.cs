using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private PlayerStatusManager playerStatusManager;
    [SerializeField] private Equipment equipment;
    [SerializeField] private EquipmentDisplay equipmentDisplay;
    [SerializeField] private Inventory inventory;
    private void Start()
    {
        foreach (EquipmentType type in Enum.GetValues(typeof(EquipmentType)))
        {
            if (type == EquipmentType.RightHand || type == EquipmentType.LeftHand)
            {
                equipment.SetItem(type, ItemList.Instance.GetItem(4));
            }
        }
        EquipmentSkillManager.instance.SettingSkill();
        int i=0;
        foreach (int ids in equipment.GetEquipmentList())
        {
            Debug.Log($"EquipmentList: {ids}, {i}");
            if (ids != 0)
            {
                equipmentDisplay.setEquipment((EquipmentType)i, ItemList.Instance.GetItem(ids));
            }
            i++;
        }
    }
    public void Equip(EquipmentType type, EquipableItem item)
    {
        equipment.SetItem(type, item);
        equipmentDisplay.setEquipment(type, item);
        playerStatusManager.itemStatChange(type, new StatStruct(item.stats));
    }
    public void Unequip(EquipmentType type)
    {
        equipment.SetItem(type, null);
        if(type == EquipmentType.RightHand || type == EquipmentType.LeftHand)
        {
            equipment.SetItem(type, ItemList.Instance.GetItem(4));
            equipmentDisplay.setEquipment(type, ItemList.Instance.GetItem(4));
        }
        else
        {
            equipmentDisplay.Clear(type);
        }
        playerStatusManager.itemStatRemove(type);
    }
}
