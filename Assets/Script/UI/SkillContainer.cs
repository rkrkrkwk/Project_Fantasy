using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillContainer : MonoBehaviour
{
    [SerializeField] private int sId = -1;
    [SerializeField] private Sprite sIcon;
    [SerializeField] private string sName;
    [SerializeField] private UnityEngine.UI.Image icon;
    [SerializeField] private TMPro.TextMeshProUGUI skillName;
    private void OnEnable()
    {
        DisplaySkill();
    }
    public void SetSkill(int id)
    {
        sId = id;
        sIcon = SkillDatabase.Instance.GetSkillData(id).icon;
        sName = SkillDatabase.Instance.GetSkillData(id).skillName;
    }
    public void DisplaySkill()
    {
        icon.sprite = sIcon;
        skillName.text = sName;
    }
    public int getsId()
    {
        return sId;
    }
}
