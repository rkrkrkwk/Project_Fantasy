using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private ProjectileData skill;
    void Update()
    {
        transform.position += transform.forward * skill.speed * Time.deltaTime;
    }
    public void SetSkill(SkillData skillData)
    {
        skill = skillData as ProjectileData;
        if (skill == null) return;
    }
    public void SetDirection(Vector3 direction)
    {
        transform.localRotation = Quaternion.LookRotation(direction);
    }
}
