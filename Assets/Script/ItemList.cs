using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ItemList : MonoBehaviour
{
    public static ItemList Instance;
    private List<Item> itemList = new List<Item>();
    private Dictionary<int, Item> itemLookupTable = new Dictionary<int, Item>();
    public IReadOnlyDictionary<int, Item> ItemLookupTable => itemLookupTable;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Initialize()
    {
        itemList = Resources.LoadAll<Item>("Item").OrderBy(item => item.id).ToList();
        foreach (Item item in itemList)
        {
            if (itemLookupTable.ContainsKey(item.id)){
                Debug.LogWarning($"Duplicate item ID detected: {item.id} for item {item.name}. Skipping this item.");
                continue;
            }
            itemLookupTable[item.id] = item;
        }
    }
    public Item GetItem(int id)
    {
        if (itemLookupTable.TryGetValue(id, out Item item))
        {
            return item;
        }
        Debug.LogWarning($"Item with ID {id} not found.");
        return null;
    }
}
