using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UiEventController
{
    public static UiEventController Instance = new UiEventController();
    private UiEventController() { }
    public Action InventoryOpen;
    public Action SkillOpen;
    public void ClickButton(UiEventType type)
    {
        switch (type)
        {
            case UiEventType.InventoryOpen:
                InventoryOpen?.Invoke();
                break;
            case UiEventType.SkillOpen:
                SkillOpen?.Invoke();
                Debug.Log("SkillOpen Invoked");
                break;
        }
    }
}