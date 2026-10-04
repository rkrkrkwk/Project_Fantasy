using System;
using UnityEngine.Timeline;
[Serializable]
public class stat
{
    // 스탯 수정자
    
    public float basic;
    public float item;
    public float final;

    public void calculate() // 최종 스탯 계산
    {
        final = basic + item;
    }
    public void reset() // 스탯 리셋
    {
        basic = 0;
        item = 0;
    }
    
    public stat () {this.basic = 0; this.item = 0; calculate();}
    public stat (float basic) // 스탯 생성 
    {
        this.basic = basic;
        this.item = 0;
        calculate();
    }
    public stat (float basic, float item)
    {
        this.basic = basic;
        this.item = item;
        calculate();
    }
    
    // 스탯 연산자
    static public stat operator +(stat s1, stat s2)
    {
        return new stat(s1.basic + s2.basic, s1.item + s2.item);
    }
    static public stat operator -(stat s1, stat s2)
    {
        return new stat(s1.basic - s2.basic, s1.item - s2.item);
    }

    // 스탯 Getter
    public float getBasic() {return basic;}
    public float getItem() {return item;}
    public float getFinal() {return final;}
};