using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Data;

[Serializable]
[CreateAssetMenu(fileName = "SkillData", menuName = "Skill/ProjectileData", order = 1)]
public class ProjectileData : SkillData
{
    [Serializable]
    public struct WeightPair
    {
        //public StatType statType;
        public float weight;
    }
    public float baseDamage;
    public float speed;
    public float range;
    public int pierce;
    public float CalculateDamage(PlayerStatusManager status)
    {
        return baseDamage;
    }
}
