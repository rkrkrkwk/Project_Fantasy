using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    [Header("Item Info")]
    public int id;
    public string itemName;
    public Sprite icon;
    [TextArea(3, 10)]
    public string flavorText;
    [Header("Item Stats")]
    public statStruct stat;
}
