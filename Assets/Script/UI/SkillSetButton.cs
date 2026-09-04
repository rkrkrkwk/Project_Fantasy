using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillSetButton : MonoBehaviour, IPointerClickHandler
{
    private SkillContainer parent;
    private SkillDisplay skillDisplay;
    private void Start()
    {
        parent = transform.parent.GetComponent<SkillContainer>();
        skillDisplay = GameObject.Find("Skill").GetComponent<SkillDisplay>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SkillSettingManager.Instance.setSkillId(parent.getsId());
        Debug.Log("Skill set to " + parent.getsId());
        skillDisplay.OpenSkillSettingDisplay();
    }
}
