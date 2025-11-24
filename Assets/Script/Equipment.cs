using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private const int MAX_EQUIPMENT = 4; // 장비 창 개수
    public EquipmentType equippedPart; // 장비한 부위
    public Item[] items = new Item[MAX_EQUIPMENT]; // 장비한 아이템 리스트

    public void equip(EquipmentType part, Item item)
    {
        items[(int)Mathf.Log((int)part, 2)] = item;
        equippedPart |= part;
        GetComponent<Inventory>().RemoveItem(item);
    }
    public void unequip(EquipmentType part)
    {
        int index = (int)Mathf.Log((int)part, 2);
        if(items[index] != null) GetComponent<Inventory>().AddItem(items[index]);
        items[index] = null;
        equippedPart &= ~part;
    }
}