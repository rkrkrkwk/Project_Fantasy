using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentHolder : MonoBehaviour, IPointerClickHandler
{
    private Item item;
    private UnityEngine.UI.Image sprite;
    [SerializeField]
    private Equipment equipment;
    [SerializeField]
    private EquipmentType equipmentType;
    void Awake()
    {
        sprite = GetComponent<UnityEngine.UI.Image>();
    }
    public void SetItem(Item newItem)
    {
        item = newItem;
        sprite.sprite = item.icon;
    }
    public void ClearItem()
    {
        item = null;
        sprite.sprite = null;
    }
    public void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if(InventoryEquipmentManager.Instance.getIndex() == -1)
            {
                Debug.Log("No item selected in inventory to equip.");
                return;
            }
            if(item != null)
            {
                InventoryEquipmentManager.Instance.DoUnequip(equipmentType, item.id);
            }
            InventoryEquipmentManager.Instance.DoEquip(equipmentType);
            Debug.Log($"Equipped item {item.name} to {equipmentType}");
        }
        else if(eventData.button == PointerEventData.InputButton.Right)
        {
            if(item == null)
            {
                Debug.Log("No item equipped to unequip.");
                return;
            }
            InventoryEquipmentManager.Instance.DoUnequip(equipmentType, item.id);
        }
    }
}
