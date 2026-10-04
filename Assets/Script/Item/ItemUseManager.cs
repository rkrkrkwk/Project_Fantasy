using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseManager : MonoBehaviour
{
    public static ItemUseManager instance;
    [SerializeField] private PlayerStatusManager playerStatusManager;
    [SerializeField] private Inventory inventory;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void UseItem(UsableItem item)
    {
        playerStatusManager.Heal(item.Heal);
        inventory.RemoveItem(item.id, 1);
    }
}
