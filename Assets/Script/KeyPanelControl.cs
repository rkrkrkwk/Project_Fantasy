using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KeyPanelControl : MonoBehaviour
{
    [SerializeField]
    private List<KeyCode> keyCodes = new List<KeyCode>(){ KeyCode.Mouse0, KeyCode.Mouse1, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4};
    private Dictionary<KeyCode, int> keySlot = new Dictionary<KeyCode, int>();
    public IReadOnlyDictionary<KeyCode, int> KeySlot => keySlot;
    public IReadOnlyList<KeyCode> KeyCodes => keyCodes;
    void Awake()
    {
        foreach (KeyCode keyCode in keyCodes)
        {
            keySlot.Add(keyCode, -1);
        }
    }
    public void SetKey(int sid, KeyCode keyCode)
    {
        keySlot[keyCode] = sid;
    }
    public int GetSkill(KeyCode keyCode)
    {
        return keySlot[keyCode];
    }
    public void RemoveKey(KeyCode keyCode)
    {
        keySlot[keyCode] = -1;
    }
}
