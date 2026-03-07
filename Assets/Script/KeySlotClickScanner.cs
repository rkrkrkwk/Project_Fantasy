using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeySlotClickScanner : MonoBehaviour, IPointerClickHandler
{
    public KeyCode keyCode = KeyCode.None;
    [SerializeField]
    private KeySettingHelper keySettingHelper;
    public void OnPointerClick(PointerEventData eventData)
    {
        
    }
}
