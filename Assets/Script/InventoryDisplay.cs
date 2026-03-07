using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject itemColumn;
    [SerializeField]
    private TMPro.TextMeshProUGUI goldText;
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    private ItemList itemList;
    private int index;
    void Start()
    {
        init();
    }
    void OnEnable()
    {
        DisplayGold();
        DisplayItem();
    }

    public void DisplayGold()
    {
        goldText.text = inventory.Gold.ToString();
    }

    public void DisplayItem()
    {
        index = 0;
        foreach (Transform child in itemColumn.transform)
        {
            foreach (Transform grandChild in child)
            {
                if (index >= inventory.InvenList.Count)
                {
                    grandChild.GetComponent<InventoryHolder>().ClearItem();
                    grandChild.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "";
                    return;
                }
                grandChild.GetComponent<InventoryHolder>().SetItem(itemList.GetItem(inventory.InvenList[index].id));
                grandChild.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = inventory.InvenList[index].quantity.ToString();
                index++;
            }
        }
    }
    public void init()
    {
        foreach (Transform child in itemColumn.transform)
        {
            foreach (Transform grandChild in child)
            {
                grandChild.GetComponent<InventoryHolder>().ClearItem();
                grandChild.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "";
            }
        }
    }
}
