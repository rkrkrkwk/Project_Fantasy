using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//플레이어의 스킬을 content의 자식으로 생성
public class SkillDisplay : MonoBehaviour
{
    [SerializeField]
    private Skill skill;
    [SerializeField]
    private SkillContainer skillContainer;
    [SerializeField]
    private GameObject content;
    [SerializeField]
    private SkillSettingDisplay skillSettingDisplay;
    List<int> skillList = new List<int>();
    private void OnEnable()
    {
        Debug.Log("DisplaySkill Activate");
        DisplaySkill();
        Debug.Log("DisplaySkill Activated");
    }
    public void DisplaySkill()
    {
        Debug.Log("DisplaySkill On");
        skillList = skill.SkillList;
        foreach (Transform child in content.transform){
            Destroy(child.gameObject);
        }
        foreach (int skillId in skillList)
        {
            SkillContainer g = Instantiate(skillContainer, content.transform);
            g.SetSkill(skillId);
            g.DisplaySkill();
        }
        Debug.Log("DisplaySkill");
    }
    public void OpenSkillSettingDisplay()
    {
        skillSettingDisplay.gameObject.SetActive(true);
    }
}
