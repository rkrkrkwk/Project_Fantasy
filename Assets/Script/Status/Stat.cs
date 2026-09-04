using System;
using UnityEngine.Timeline;
[Serializable]
public class stat
{
    // 스탯 수정자
    private float basic;
    private float final;

    public void calculate() // 최종 스탯 계산
    {
        final = basic;
    }
    public void reset() // 스탯 리셋
    {
        basic = 0;
    }
    
    public stat () {this.basic = 0;}
    public stat (float basic) // 스탯 생성 
    {
        this.basic = basic;
    }
    
    // 스탯 연산자
    static public stat operator +(stat s1, stat s2)
    {
        return new stat(s1.basic + s2.basic);
    }
    static public stat operator -(stat s1, stat s2)
    {
        return new stat(s1.basic - s2.basic);
    }

    // 스탯 Getter
    public float getBasic() {return basic;}
};