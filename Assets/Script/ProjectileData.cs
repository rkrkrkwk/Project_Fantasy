using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "SkillData", menuName = "Skill/ProjectileData", order = 1)]
public class ProjectileData : SkillData
{
    public float damage;
    public float speed;
    public override void Execute()
    {
        Debug.Log("Projectile has been executed");
    }
}
