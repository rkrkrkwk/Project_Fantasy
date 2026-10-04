using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "SkillData", menuName = "Skill/SlashData", order = 1)]
public class SlashData : SkillData
{
    public float startAngle;
    public float endAngle;
    public float movespeed;
}
