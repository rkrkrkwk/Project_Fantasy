using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "SkillData", menuName = "Skill/SlashData", order = 1)]
public class SlashData : SkillData
{
    public float size;
    public float startAngle;
    public float endAngle;
    public float movespeed;
    [Serializable] public struct DamageMultiplier
    {
        public StatType statType;
        public float multiplier;
    }
    public List<DamageMultiplier> damageMultipliers;
    public float getDamage(StatStruct stat)
    {
        float damage = 0;
        foreach(DamageMultiplier damageMultiplier in damageMultipliers)
        {
            damage += stat.getStat(damageMultiplier.statType) * damageMultiplier.multiplier;
        }
        return damage;
    }
}
