using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item/Usable")]
public class UsableItem : Item
{
    public float Heal;
}
