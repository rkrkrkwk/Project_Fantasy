using System;
[Serializable]
public class statStruct
{
    public float AddMaxHP;
    public float AddMaxMP;
    public float AddATK;
    public float AddMAT;
    public float LV;
    public float MaxHP;
    public float MaxMP;
    public float HP;
    public float MP;
    public float ATK;
    public float MAT;

    public statStruct(float addMaxHP, float addMaxMP, float addATK, float addMAT, float lv, float maxHP, float maxMP, float hp, float mp, float atk, float mat)
    {
        AddMaxHP = addMaxHP;
        AddMaxMP = addMaxMP;
        AddATK = addATK;
        AddMAT = addMAT;
        LV = lv;
        MaxHP = maxHP;
        MaxMP = maxMP;
        HP = hp>maxHP?maxHP:hp;
        MP = mp>maxMP?maxMP:mp;
        ATK = atk;
        MAT = mat;
    }
    public statStruct() {}
    public statStruct(statStruct stat) 
    { 
        AddMaxHP = stat.AddMaxHP;
        AddMaxMP = stat.AddMaxMP;
        AddATK = stat.AddATK;
        AddMAT = stat.AddMAT;
        LV = stat.LV;
        MaxHP = stat.MaxHP;
        MaxMP = stat.MaxMP;
        HP = stat.HP;
        MP = stat.MP;
        ATK = stat.ATK;
        MAT = stat.MAT;
    }

    public static statStruct operator +(statStruct a, statStruct b)
    {
        statStruct res = new statStruct();
        res.AddMaxHP = a.AddMaxHP + b.AddMaxHP;
        res.AddMaxMP = a.AddMaxMP + b.AddMaxMP;
        res.AddATK = a.AddATK + b.AddATK;
        res.AddMAT = a.AddMAT + b.AddMAT;
        res.LV = a.LV + b.LV;
        res.MaxHP = a.MaxHP + b.MaxHP;
        res.MaxMP = a.MaxMP + b.MaxMP;
        res.HP = a.HP + b.HP;
        res.MP = a.MP + b.MP;
        res.ATK = a.ATK + b.ATK;
        res.MAT = a.MAT + b.MAT;
        return res;
    }
    public static statStruct operator -(statStruct a, statStruct b)
    {
        statStruct res = new statStruct();
        res.AddMaxHP = a.AddMaxHP - b.AddMaxHP;
        res.AddMaxMP = a.AddMaxMP - b.AddMaxMP;
        res.AddATK = a.AddATK - b.AddATK;
        res.AddMAT = a.AddMAT - b.AddMAT;
        res.LV = a.LV - b.LV;
        res.MaxHP = a.MaxHP - b.MaxHP;
        res.MaxMP = a.MaxMP - b.MaxMP;
        res.HP = a.HP - b.HP;
        res.MP = a.MP - b.MP;
        res.ATK = a.ATK - b.ATK;
        res.MAT = a.MAT - b.MAT;
        return res;
    }

    public void setStat(float addMaxHP, float addMaxMP, float addATK, float addMAT, float lv, float maxHP, float maxMP, float hp, float mp, float atk, float mat)
    {
        AddMaxHP = addMaxHP;
        AddMaxMP = addMaxMP;
        AddATK = addATK;
        AddMAT = addMAT;
        LV = lv;
        MaxHP = maxHP;
        MaxMP = maxMP;
        HP = hp>maxHP?maxHP:hp;
        MP = mp>maxMP?maxMP:mp;
        ATK = atk;
        MAT = mat;
    }

    public void resetStat()
    {
        AddMaxHP = 0;
        AddMaxMP = 0;
        AddATK = 0;
        AddMAT = 0;
        LV = 0;
        MaxHP = 0;
        MaxMP = 0;
        HP = 0;
        MP = 0;
        ATK = 0;
        MAT = 0;
    }

    public void addStat(float addMaxHP, float addMaxMP, float addATK, float addMAT, float lv, float maxHP, float maxMP, float hp, float mp, float atk, float mat)
    {
        AddMaxHP += addMaxHP;
        AddMaxMP += addMaxMP;
        AddATK += addATK;
        AddMAT += addMAT;
        LV += lv;
        MaxHP += maxHP;
        MaxMP += maxMP;
        HP += hp;
        MP += mp;
        ATK += atk;
        MAT += mat;
    }
};