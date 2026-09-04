using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SkillExecutor : MonoBehaviour
{
    void Update()
    {
        foreach (Actions action in ActionSkillControl.Instance.actions)
        {
            if (Input.GetKeyDown(KeyControl.Instance.GetKey(action)))
            {
                int sid = ActionSkillControl.Instance.SkillSlot[action];
                if (sid == -1) continue;
                else
                    ExecuteSkill(SkillDatabase.Instance.GetSkillData(sid));
            }
        }
    }
    public void ExecuteSkill(SkillData skillData)
    {
        if(skillData is ProjectileData)
        {
            GameObject projectile = Instantiate(skillData.prefab, transform.position, transform.rotation);
        }
    }
    public float calcSkillDamage (SkillData skillData)
    {
        return 1f;
    }
}