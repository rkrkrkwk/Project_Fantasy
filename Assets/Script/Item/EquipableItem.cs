using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Equipable")]
public class EquipableItem : Item
{
    [Header("Item Stats/MaxHP, ATK, DEF")]
    public stat[] stats;
    public List<int> skills;
}
    
