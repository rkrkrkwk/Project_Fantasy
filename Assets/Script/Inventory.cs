using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class Inventory : MonoBehaviour
{    
    private List<Item> items = new List<Item>();
    public int gold = 0;

    public List<Item> Items { get => items; set => items = value; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
    
    public void AddGold(int amount)
    {
        gold += amount;
    }
}
