using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayGold();
        DisplayItem();
    }

    public void DisplayGold()
    {
        gameObject.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = player.GetComponent<Inventory>().gold.ToString();
    }

    public void DisplayItem()
    {
        for (int i = 0; i < gameObject.transform.GetChild(0).transform.childCount; i++)
        {
            for (int j = 0; j < gameObject.transform.GetChild(0).transform.GetChild(i).childCount; j++)
            {
                if (i * 5 + j < player.GetComponent<Inventory>().Items.Count)
                    gameObject.transform.GetChild(0).transform.GetChild(i).GetChild(j).GetComponent<ItemHolderControl>().item = player.GetComponent<Inventory>().Items[i * 5 + j];
                if (i * 5 + j >= player.GetComponent<Inventory>().Items.Count)
                {
                    gameObject.transform.GetChild(0).transform.GetChild(i).GetChild(j).GetComponent<ItemHolderControl>().item = null;
                }
            }
        }
    }
}
