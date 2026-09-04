using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillExecuteManger : MonoBehaviour
{
    public static SkillExecuteManger Instance = new SkillExecuteManger();
    
    public void ExecuteSkill(int sid, string targetTag, Transform caster)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePosition.y - caster.position.y, mousePosition.x - caster.position.x) * Mathf.Rad2Deg;
        GameObject skill = Instantiate(SkillDatabase.Instance.GetSkillData(sid).prefab, caster.position, Quaternion.Euler(0, 0, angle-90));
        skill.GetComponent<Projectile>().SetSkill(SkillDatabase.Instance.GetSkillData(sid), targetTag, caster.gameObject);
    }
}
