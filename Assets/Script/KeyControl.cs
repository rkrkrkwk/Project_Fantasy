using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//키 입력에 액션 대응
public class KeyControl
{
    public static KeyControl Instance {get; private set;}
    public const int MAX_SKILL = 6;
    private Dictionary<Action, KeyCode> key = new Dictionary<Action, KeyCode>();
    public void init()
    {
        for (int i = 0; i < MAX_SKILL; i++)
        {
            key.Add((Action)i, KeyCode.None);
        }
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
