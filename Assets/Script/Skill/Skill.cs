using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private List<int> skillList = new List<int>();
    public List<int> SkillList { get => skillList; }
    public void AddSkill(int id)
    {
        if(SkillDatabase.Instance.SkillLookupTable.ContainsKey(id)){
            if(!skillList.Exists(x => x == id))
            {
                Debug.Log("Skill added");
                skillList.Add(id);
            }
            else
            {
                Debug.Log("Skill already exists");
            }
        }
        else
        {
            Debug.Log("Skill not found");
        }
    }
    public void removeSkill(int id)
    {
        if (skillList.Exists(x => x == id))
        {
            skillList.Remove(id);
        }
        else
        {
            Debug.Log("Skill not found");
        }
    }
}
