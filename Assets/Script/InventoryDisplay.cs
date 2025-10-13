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
        bool ItemEnded = false;
        for (int i = 0; i < gameObject.transform.GetChild(0).transform.childCount; i++)
        {
            for (int j = 0; j < gameObject.transform.GetChild(0).transform.GetChild(i).childCount; j++)
            {
                if (player.GetComponent<Inventory>().Items.Count > i * 5 + j)
                {
                    gameObject.transform.GetChild(0).transform.GetChild(i).GetChild(j).GetComponent<UnityEngine.UI.Image>().sprite = player.GetComponent<Inventory>().Items[i * 5 + j].icon;
                }
                else
                {
                    ItemEnded = true;
                    Debug.Log(i * 5 + j);
                    break;
                }
            }
            if (ItemEnded) break;
        }
    }
}
