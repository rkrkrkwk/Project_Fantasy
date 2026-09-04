using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContentDisplay : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    
    public void UpdateInventoryDisplay()
    {
        int index=0;
        // count child
        Debug.Log("InventoryContentDisplay: Number of children in inventory panel: " + transform.childCount);
        // Clear existing inventory display
        foreach (Transform child in transform)
        {
            Debug.Log("show item " + index);
            child.GetComponent<InventoryHolder>().ShowItem(inventory.InventoryItems[index].itemID, inventory.InventoryItems[index].quantity);
            index++;
        }
    }
}
