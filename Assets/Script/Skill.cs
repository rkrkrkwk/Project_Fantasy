using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private List<SkillData> skillList = new List<SkillData>();
    public List<SkillData> SkillList { get => skillList; }
    public void AddSkill(int id)
    {
        if(skillList.Find(x => x.skillId == id) == null)
        {
            SkillDatabase instant = SkillDatabase.Instance;
            Debug.Log(instant.GetSkillData(id).skillName);
            skillList.Add(SkillDatabase.Instance.GetSkillData(id));
        }
        else
        {
            Debug.Log("Skill already exists");
        }
    }
    public void removeSkill(int id)
    {
        if (skillList.Find(x => x.skillId == id) != null)
        {
            skillList.Remove(SkillDatabase.Instance.GetSkillData(id));
        }
        else
        {
            Debug.Log("Skill not found");
        }
    }
}
