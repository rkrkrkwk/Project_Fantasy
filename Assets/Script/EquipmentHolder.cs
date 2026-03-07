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
    Coroutine clickCoroutine;
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
    }
    private void SingleLeftClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        Debug.Log(equipment.GetItem(EquipmentType.LeftHand) == null ? "nothing" : equipment.GetItem(EquipmentType.LeftHand).itemName + " is used to " + (item == null ? "nothing" : item.itemName));
    }
    private void SingleRightClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        Debug.Log(equipment.GetItem(EquipmentType.RightHand) == null ? "nothing" : equipment.GetItem(EquipmentType.RightHand).itemName + " is used to " + (item == null ? "nothing" : item.itemName));
    }
    private void DoubleLeftClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        equipment.SwitchEquipment(EquipmentType.LeftHand, equipmentType);
    }
    private void DoubleRightClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        equipment.SwitchEquipment(EquipmentType.RightHand, equipmentType);
    }
}
