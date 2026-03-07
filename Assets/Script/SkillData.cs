using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.Unity.VisualStudio.Editor;

[Serializable]
[CreateAssetMenu(fileName = "SkillData", menuName = "Skill/SkillData", order = 1)]
public class SkillData : ScriptableObject
{
    public int skillId;
    public string skillName;
    public string flavorText;
    public int damage;
    public int cost;
    public UnityEngine.Sprite sprite;
}

