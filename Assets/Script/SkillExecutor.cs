using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SkillExecutor : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Skill skill;
    void Update()
    {
        if (Input.GetKeyDown(KeyControl.Instance.GetKey(Action.skill1)))
        {
            int sid = ActionSkillControl.Instance.SkillSlot[Action.skill1];
            if (sid == -1) return;
            else
                SkillDatabase.Instance.GetSkillData(sid).Execute();
        }
    }
    public void ExecuteSkill(SkillData skillData)
    {
        if(skillData is ProjectileData)
        {
            GameObject projectile = Instantiate(skillData.prefab, player.transform.position, quaternion.identity);
            projectile.GetComponent<Projectile>().SetSkill(skillData);
        }
    }
}