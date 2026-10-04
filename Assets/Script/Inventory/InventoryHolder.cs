using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryHolder : MonoBehaviour, IPointerClickHandler
{
    private int id;
    private int index;
    [SerializeField] private UnityEngine.UI.Image iconImage;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Sprite defaultIcon;
    private void Start()
    {
        Debug.Log("InventoryHolder Started");
    }

    public void ShowItem(int id, int quantity)
    {
        this.id = id;
        if (id == -1)
        {
            iconImage.sprite = null;
            quantityText.text = "";
            Debug.Log("InventoryHolder: No item to display");
            return;
        }
        iconImage.sprite = ItemList.Instance.GetItem(id).icon;
        quantityText.text = quantity.ToString();
        Debug.Log($"InventoryHolder: Displaying item ID {id} with quantity {quantity}");
    }

    public void setIndex(int idx)
    {
        index = idx;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (ItemList.Instance.GetItem(id).itemType)
        {
            case ItemType.Equipable:
                {
                    if(iconImage.sprite == null)
                    {
                        Debug.Log("InventoryHolder: No item to select");
                        return;
                    }
                    InventoryEquipmentManager.Instance.SetIndex(index);
                }
                break;
            case ItemType.Usable:
                {
                    ItemUseManager.instance.UseItem((UsableItem)ItemList.Instance.GetItem(id));
                }
                break;
            default:
                break;
            
        }
    }
}
