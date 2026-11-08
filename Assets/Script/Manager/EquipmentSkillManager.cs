using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSkillManager : MonoBehaviour
{
    [SerializeField] private Skill playerSkill;
    [SerializeField] private Equipment equipment;
    public static EquipmentSkillManager instance;
    private List<int> aqquireSkillList = new List<int>();
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
    public void SettingSkill()
    {
        playerSkill.removeEquipmentSkill(aqquireSkillList);
        aqquireSkillList.Clear();
        List<int> equips = equipment.GetEquipmentList();
        foreach (int id in equips)
        {
            if (id != 0)
            {
                EquipableItem temp = (EquipableItem)ItemList.Instance.GetItem(id);
                if (temp.skills.Count > 0)
                {
                    foreach (int skillId in temp.skills)
                    {
                        if (!aqquireSkillList.Contains(skillId))
                        {
                            aqquireSkillList.Add(skillId);
                        }
                    }
                } 
            }
        }
        playerSkill.AddEquipmentSkill(aqquireSkillList);
    }
}
