using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField]
    private Equipment equipment;
    [SerializeField]
    private EquipmentDisplay equipmentDisplay;
    [SerializeField]
    private Inventory inventory;
    public void Equip(EquipmentType type, Item item)
    {
        equipment.SetItem(type, item);
        equipmentDisplay.setEquipment(type, item);
    }
    public void Unequip(EquipmentType type)
    {
        equipment.SetItem(type, null);
        equipmentDisplay.Clear(type);
    }
}
