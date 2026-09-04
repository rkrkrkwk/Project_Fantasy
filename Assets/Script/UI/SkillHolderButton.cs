using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillHolderButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]private UnityEngine.UI.Image iconHolder;
    [SerializeField]private int skillSlot;
    private int skillId = -1;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (skillSlot == -1)
        {
            Debug.LogError("Slot Setting Error");
        }
        skillId = SkillSettingManager.Instance.getSkillId();
        SkillSettingManager.Instance.setSkill(skillSlot);
        ShowIcon();
    }
    public void ShowIcon()
    {
        if (skillId != -1)
        {
            iconHolder.sprite = SkillDatabase.Instance.GetSkillData(skillId).icon;
        }
        else
        {
            iconHolder.sprite = null;
        }
    }
}
