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
    private List<KeySlotControl> keySlotControls = new List<KeySlotControl>();
    private Dictionary<Actions, KeySlotControl> keySlotControlDict = new Dictionary<Actions, KeySlotControl>();
    void Awake()
    {
        foreach (KeySlotControl keySlotControl in keySlotControls)
        {
            keySlotControlDict.Add(keySlotControl.getAction(), keySlotControl);
        }
    }
    public void DisplayKeySlot()
    {
        foreach ( var pair in keySlotControlDict)
        {
            pair.Value.SetSkill(ActionSkillControl.Instance.GetSkill(pair.Key));
        }
    }
}
