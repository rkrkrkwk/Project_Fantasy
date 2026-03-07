using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//플레이어의 스킬을 content의 자식으로 생성
public class SkillDisplay : MonoBehaviour
{
    [SerializeField]
    private Skill skill;
    [SerializeField]
    private SkillPanelControl skillPanelControl;
    [SerializeField]
    private GameObject content;
    private SkillListControl skillListControl;
    void Awake()
    {
        skillListControl = content.GetComponent<SkillListControl>();
        
    }
    void OnEnable()
    {
        DisplaySkill();
    }
    public void DisplaySkill()
    {
        List<SkillData> skillList = skill.SkillList;
        skillListControl.ClearList();
        foreach (SkillData skill in skillList)
        {
            SkillPanelControl g = Instantiate(skillPanelControl, content.transform);
            g.SetSkill(skill.skillId, skill.skillName, skill.sprite);
        }
    }
}
