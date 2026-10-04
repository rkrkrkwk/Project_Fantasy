using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Linq;
[Serializable]
public class StatStruct
{
    private List<stat> statList = new List<stat>();
    private Dictionary<StatType, stat> statDict = new Dictionary<StatType, stat>();
    public IReadOnlyDictionary<StatType, stat> StatDict => statDict;
    public IReadOnlyList<stat> StatList => statList;
    
    public StatStruct()
    {
        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            statList.Add(new stat());
            statDict.Add(statType, statList[(int)statType]);
        }
    }
    public StatStruct(float[] floats)
    {
        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            statList.Add(new stat(floats[(int)statType]));
            statDict.Add(statType, statList[(int)statType]);
        }
    }
    public StatStruct(float[] floats, float[] items)
    {
        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            statList.Add(new stat(floats[(int)statType], items[(int)statType]));
            statDict.Add(statType, statList[(int)statType]);
        }
    }
    public StatStruct(stat[] statArray)
    {
        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            statList.Add(new stat(statArray[(int)statType].getBasic(), statArray[(int)statType].getItem()));
            statDict.Add(statType, statList[(int)statType]);
        }
    }

    static public StatStruct operator +(StatStruct s1, StatStruct s2)
    {
        stat[] statArray = new stat[4];
        foreach(StatType statType in Enum.GetValues(typeof(StatType)))
        {
            statArray[(int)statType] = s1.statDict[statType] + s2.statDict[statType];
        }
        return new StatStruct(statArray);
    }

    static public StatStruct operator -(StatStruct s1, StatStruct s2)
    {
        stat[] statArray = new stat[4];
        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            statArray[(int)statType] = s1.statDict[statType] - s2.statDict[statType];
        }
        return new StatStruct(statArray);
    }

    public void calcAll()
    {
        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            statDict[statType].calculate();
        }
    }

    public void reset()
    {
        foreach (StatType statType in Enum.GetValues(typeof(StatType)))
        {
            statDict[statType].reset();
        }
    }
    public float getStat(StatType statType)
    {
        return statDict[statType].getFinal();
    }
}
