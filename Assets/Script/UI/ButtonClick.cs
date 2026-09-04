using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class ButtonClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private UiEventType eventType;
    public void OnPointerClick(PointerEventData eventData)
    {
        UiEventController.Instance.ClickButton(eventType);
        Debug.Log(eventType + " has been clicked");
    }
}
