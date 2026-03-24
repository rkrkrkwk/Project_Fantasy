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
        public StatType statType;
        public float weight;
    }
    public float baseDamage;
    public WeightPair[] weightPairs;
    public float speed;
    public float range;
    public int pierce;
    public float CalculateDamage(Status status)
    {
        float Damage = 0;
        Damage += baseDamage;
        foreach (WeightPair pair in weightPairs)
        {
            if(pair.statType == StatType.HP)
            {
                Damage += pair.weight * status.hp;
            }
            else if (pair.statType == StatType.MP)
            {
                Damage += pair.weight * status.mp;
            }
            else
            {
                Damage += pair.weight * status.stat.getStat(pair.statType);
            }
        }
        return Damage;
    }
}
