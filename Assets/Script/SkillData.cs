using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.Unity.VisualStudio.Editor;

[Serializable]
[CreateAssetMenu(fileName = "SkillData", menuName = "Skill/SkillData", order = 1)]
public abstract class SkillData : ScriptableObject
{
    public int skillId;
    public string skillName;
    public string flavorText;
    public UnityEngine.Sprite icon;
    public GameObject prefab;
    public abstract void Execute();
}

