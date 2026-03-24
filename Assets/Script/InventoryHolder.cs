using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryHolder : MonoBehaviour, IPointerClickHandler
{
    private Item item;
    private UnityEngine.UI.Image sprite;
    private Equipment equipment;
    Coroutine clickCoroutine;
    void Awake()
    {
        equipment = GameObject.FindGameObjectWithTag("Player").GetComponent<Equipment>();
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
        if (clickCoroutine != null)
        {
            StopCoroutine(clickCoroutine);
        }
        if (eventData.clickCount == 1)
        {
            clickCoroutine = StartCoroutine(ClickDelay(eventData));
        }
        else if (eventData.clickCount == 2)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                DoubleLeftClick(eventData);
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                DoubleRightClick(eventData);
            }
            if (clickCoroutine != null)
            {
                StopCoroutine(clickCoroutine);
                clickCoroutine = null;
            }
        }
    }
    private IEnumerator ClickDelay(UnityEngine.EventSystems.PointerEventData eventData)
    {
        yield return new WaitForSeconds(0.3f);
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            SingleLeftClick(eventData);
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            SingleRightClick(eventData);
        }
        clickCoroutine = null;
    }
    private void SingleLeftClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        Debug.Log("Use " + (equipment.Items[EquipmentType.LeftHand]==null ? "nothing" : equipment.Items[EquipmentType.LeftHand].itemName) + " on " + (item == null ? "nothing" : item.itemName));
    }
    private void SingleRightClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        Debug.Log("Use " + (equipment.Items[EquipmentType.RightHand]==null ? "nothing" : equipment.Items[EquipmentType.RightHand].itemName) + " on " + (item == null ? "nothing" : item.itemName));
    }
    public void DoubleLeftClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (item == null)
        {
            if (equipment.Items[EquipmentType.LeftHand] != null)
            {
                equipment.Unequip(EquipmentType.LeftHand);
            }
            return;
        }
        equipment.Equip(EquipmentType.LeftHand, item);
    }
    public void DoubleRightClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        if (item == null)
        {
            if (equipment.Items[EquipmentType.RightHand] != null)
            {
                equipment.Unequip(EquipmentType.RightHand);
            }
            return;
        }
        equipment.Equip(EquipmentType.RightHand, item);
    }
}
