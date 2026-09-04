using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class KeySlotControl : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private KeyCode keyCode;
    private UnityEngine.UI.Image sprite;
    [SerializeField]
    private Actions action;
    private int sid;
    void Awake()
    {
        sprite = GetComponent<UnityEngine.UI.Image>();
    }
    public void SetSkill(int skillId)
    {
        if (skillId <= 0) return;
        sid = skillId;
        sprite.sprite = SkillDatabase.Instance.GetSkillData(sid).icon;
    }
    public KeyCode getKeyCode()
    {
        return keyCode;
    } 
    public Actions getAction()
    {
        return action;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (KeySettingHelper.Instance.getSetter() != -1)
            {
                SetSkill(KeySettingHelper.Instance.getSetter());
                ActionSkillControl.Instance.SetSkill(sid, action);
                KeySettingHelper.Instance.setSetter(-1);
            }
        }
    }
}
