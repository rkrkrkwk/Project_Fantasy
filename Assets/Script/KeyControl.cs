using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//키 입력에 액션 대응
public class KeyControl
{
    public static KeyControl Instance {get; private set;} = new KeyControl();
    public const int MAX_SKILL = 6;
    private Dictionary<Action, KeyCode> key = new Dictionary<Action, KeyCode>();
    KeyControl() { init(); }
    public void init()
    {
        key.Add(Action.skill1, KeyCode.Mouse0);
        key.Add(Action.skill2, KeyCode.Mouse1);
        key.Add(Action.skill3, KeyCode.Alpha1);
        key.Add(Action.skill4, KeyCode.Alpha2);
        key.Add(Action.skill5, KeyCode.Alpha3);
        key.Add(Action.skill6, KeyCode.Alpha4);
    }
    public void SetKey(Action action, KeyCode keyCode)
    {
        key[action] = keyCode;
    }
    public KeyCode GetKey(Action action)
    {
        return key[action];
    }
}
