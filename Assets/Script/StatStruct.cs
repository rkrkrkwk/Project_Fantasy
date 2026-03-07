using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
[Serializable]
public class StatStruct
{
    public stat MaxHP;
    public stat MaxMP;
    public stat ATK;
    public stat DEF;
    
    public StatStruct()
    {
        this.MaxHP = new stat();
        this.MaxMP = new stat();
        this.ATK = new stat();
        this.DEF = new stat();
    }
    public StatStruct(stat MaxHP, stat MaxMP, stat ATK, stat DEF)
    {
        this.MaxHP = MaxHP;
        this.MaxMP = MaxMP;
        this.ATK = ATK;
        this.DEF = DEF;
    }

    static public StatStruct operator +(StatStruct s1, StatStruct s2)
    {
        return new StatStruct(s1.MaxHP + s2.MaxHP, s1.MaxMP + s2.MaxMP, s1.ATK + s2.ATK, s1.DEF + s2.DEF);
    }

    static public StatStruct operator -(StatStruct s1, StatStruct s2)
    {
        return new StatStruct(s1.MaxHP - s2.MaxHP, s1.MaxMP - s2.MaxMP, s1.ATK - s2.ATK, s1.DEF - s2.DEF);
    }

    public void calcAll()
    {
        MaxHP.calculate();
        MaxMP.calculate();
        ATK.calculate();
        DEF.calculate();
    }

    public void reset()
    {
        MaxHP = new stat();
        MaxMP = new stat();
        ATK = new stat();
        DEF = new stat();
    }
}
