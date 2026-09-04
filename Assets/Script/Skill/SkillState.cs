using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillState
{
    private SkillData skillData;
    public SkillState(int id)
    {
        this.skillData = SkillDatabase.Instance.GetSkillData(id);
    }
}
