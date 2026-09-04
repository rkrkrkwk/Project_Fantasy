using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//키 입력에 액션 대응
public class KeyControl
{
    public static KeyControl Instance {get; private set;} = new KeyControl();
    public const int MAX_SKILL = 6;
    private Dictionary<Actions, KeyCode> key = new Dictionary<Actions, KeyCode>();
    KeyControl() { init(); }
    public void init()
    {
        key.Add(Actions.skill1, KeyCode.Mouse0);
        key.Add(Actions.skill2, KeyCode.Mouse1);
        key.Add(Actions.skill3, KeyCode.Alpha1);
        key.Add(Actions.skill4, KeyCode.Alpha2);
        key.Add(Actions.skill5, KeyCode.Alpha3);
        key.Add(Actions.skill6, KeyCode.Alpha4);
    }
    public void SetKey(Actions action, KeyCode keyCode)
    {
        key[action] = keyCode;
    }
    public KeyCode GetKey(Actions action)
    {
        return key[action];
    }
}
