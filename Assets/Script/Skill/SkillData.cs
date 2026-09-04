using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "SkillData", menuName = "Skill/SkillData", order = 1)]
public class SkillData : ScriptableObject
{
    public int skillId;
    public string skillName;
    public string flavorText;
    public UnityEngine.Sprite icon;
    public GameObject prefab;
}

