using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillPanelControl : MonoBehaviour , IPointerClickHandler
{
    private int sid;
    [SerializeField]
    private TextMeshProUGUI skillNameText;
    [SerializeField]
    private UnityEngine.UI.Image skillImage;
    public void SetSkill(int skillId, string skillName, Sprite skillImage) {
        sid = skillId;
        skillNameText.text = skillName;
        this.skillImage.sprite = skillImage;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            KeySettingHelper.Instance.setSetter(sid);
        }
    }
}
