using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
[Serializable]
public class stat
{
    // basic stat decide by level
    public float basic;
    // modifier decide by item, skill, etc
    public float modifier;
    // percent modifier decide by item, skill, etc
    public float percent;
    // final stat
    private float final;
    public float Final { get => final; }

    public void calculate()
    {
        final = (basic + modifier) * (1 + percent);
    }

    
    public stat (float basic, float modifier, float percent) 
    {
        this.basic = basic;
        this.modifier = modifier;
        this.percent = percent;
        calculate();
    }

    public stat (float basic) 
    {
        this.basic = basic;
        this.modifier = 0;
        this.percent = 0;
        calculate();
    }

    public stat()
    {
        this.basic = 0;
        this.modifier = 0;
        this.percent = 0;
        calculate();
    }
    
    static public stat operator +(stat s1, stat s2)
    {
        return new stat(s1.basic + s2.basic, s1.modifier + s2.modifier, s1.percent + s2.percent);
    }
    static public stat operator -(stat s1, stat s2)
    {
        return new stat(s1.basic - s2.basic, s1.modifier - s2.modifier, s1.percent - s2.percent);
    }
};