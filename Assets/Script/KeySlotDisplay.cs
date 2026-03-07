using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;

public class KeySlotDisplay : MonoBehaviour
{
    [SerializeField]
    private KeyPanelControl keyPanelControl;
    [SerializeField]
    private List<KeySlotControl> keySlotControls = new List<KeySlotControl>();
    private Dictionary<KeyCode, KeySlotControl> keySlotControlDict = new Dictionary<KeyCode, KeySlotControl>();
    void Awake()
    {
        foreach (KeySlotControl keySlotControl in keySlotControls)
        {
            keySlotControlDict.Add(keySlotControl.getKeyCode(), keySlotControl);
        }
    }
    public void DisplayKeySlot()
    {
        foreach ( var pair in keySlotControlDict)
        {
            pair.Value.SetSkill(keyPanelControl.GetSkill(pair.Key));
        }
    }
}
