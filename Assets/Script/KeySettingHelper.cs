using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySettingHelper
{
    public static KeySettingHelper Instance { get; private set; } = new KeySettingHelper();
    int setter;

    public void setSetter(int setter) { this.setter = setter; }
    public int getSetter() { return setter; }
}
