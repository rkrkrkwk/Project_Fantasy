using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceLoader : MonoBehaviour
{
    void Start()
    {
        SkillSettingManager.Instance.init();
    }
}
