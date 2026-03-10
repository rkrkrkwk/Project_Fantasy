using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class ActionSkillControl
{
    [SerializeField]
    private List<Action> Actions = new List<Action>(){ Action.skill1, Action.skill2, Action.skill3, Action.skill4, Action.skill5, Action.skill6};
    private Dictionary<Action, int> skillSlot = new Dictionary<Action, int>();
    public IReadOnlyDictionary<Action, int> SkillSlot => skillSlot;
    public IReadOnlyList<Action> actions => Actions;
    public static ActionSkillControl Instance { get; private set; } = new ActionSkillControl();
    ActionSkillControl() { Init(); }
    void Init()
    {
        foreach (Action action in Actions)
        {
            skillSlot.Add(action, -1);
        }
    }
    public void SetSkill(int sid, Action keyCode)
    {
        skillSlot[keyCode] = sid;
        Debug.Log("Key has been set" + keyCode + " " + sid);
    }
    public int GetSkill(Action action)
    {
        return skillSlot[action];
    }
    public void RemoveSkill(Action action)
    {
        skillSlot[action] = -1;
    }
}
