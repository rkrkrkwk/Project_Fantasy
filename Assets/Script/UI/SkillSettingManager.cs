using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillSlot
{
    Mouse0, Mouse1, Alpha1, Alpha2, Alpha3, Alpha4, Alpha5, Z, X, C, V, B, F, R, Q, T, G, Shift
}
public class SkillSettingManager
{
    public static SkillSettingManager Instance = new SkillSettingManager();
    public static int skillId = -1;
    public static int[] skillSlot = new int [18];
    public void init()
    {
        string temp = " ";
        foreach (int i in skillSlot)
        {
            skillSlot[i] = -1;
            temp = temp + skillSlot[i] + " ";
        }
        Debug.Log("Skill Setting Init" + temp);
    }
    public void setSkillId(int id)
    {
        skillId = id;
    }
    public void setSkill(int slot)
    {
        skillSlot[slot] = skillId;
    }
    public void removeSkill(int slot)
    {
        skillSlot[slot] = -1;
    }
    public int getSkillId()
    {
        return skillId;
    }
    public int getSkill(int slot)
    {
        return skillSlot[slot];
    }
}
