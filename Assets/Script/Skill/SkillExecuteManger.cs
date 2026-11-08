using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillExecuteManger : MonoBehaviour
{
    public static SkillExecuteManger instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void ExecuteSkill(int sid, string targetTag, Transform caster)
    {
        if (ObjectLimitManager.instance.CheckObjectCount(sid))
        {
            Debug.Log("Skill execution aborted: object limit reached for skill id " + sid);
            return;
        }
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePosition.y - caster.position.y, mousePosition.x - caster.position.x) * Mathf.Rad2Deg;
        GameObject skill = Instantiate(SkillDatabase.Instance.GetSkillData(sid).prefab, caster.position, Quaternion.Euler(0, 0, angle-90));
        switch(SkillDatabase.Instance.GetSkillData(sid).type)
        {
            case SkillType.Projectile:
                {
                    skill.GetComponent<Projectile>().SetSkill((ProjectileData)SkillDatabase.Instance.GetSkillData(sid), targetTag, caster.gameObject);
                    break;
                }
            case SkillType.Slash:
                {
                    skill.GetComponent<Slash>().SetSkill((SlashData)SkillDatabase.Instance.GetSkillData(sid), mousePosition, caster);
                    break;
                }
        }
    }
}
