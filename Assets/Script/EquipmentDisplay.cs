using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayEquipment();
    }

    public void DisplayEquipment()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Equipment equipment = player.GetComponent<Equipment>();
        for (int i = 1; i < gameObject.transform.childCount; i++)
        {
            if (equipment.items[i - 1] != null)
                gameObject.transform.GetChild(i).GetComponent<ItemHolderControl>().item = equipment.items[i - 1];
            else
                gameObject.transform.GetChild(i).GetComponent<ItemHolderControl>().item = null;
        }
    }
}
