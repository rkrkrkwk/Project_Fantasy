using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ActionSkillControl
{
    [SerializeField]
    private List<Actions> Action = new List<Actions>(){ Actions.skill1, Actions.skill2, Actions.skill3, Actions.skill4, Actions.skill5, Actions.skill6};
    private Dictionary<Actions, int> skillSlot = new Dictionary<Actions, int>();
    public IReadOnlyDictionary<Actions, int> SkillSlot => skillSlot;
    public IReadOnlyList<Actions> actions => Action;
    public static ActionSkillControl Instance { get; private set; } = new ActionSkillControl();
    ActionSkillControl() { Init(); }
    void Init()
    {
        foreach (Actions action in Action)
        {
            skillSlot.Add(action, -1);
        }
    }
    public void SetSkill(int sid, Actions keyCode)
    {
        skillSlot[keyCode] = sid;
        Debug.Log("Key has been set" + keyCode + " " + sid);
    }
    public int GetSkill(Actions action)
    {
        return skillSlot[action];
    }
    public void RemoveSkill(Actions action)
    {
        skillSlot[action] = -1;
    }
}
