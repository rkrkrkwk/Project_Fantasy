using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class Status : MonoBehaviour
{
    public statStruct status;
    // Start is called before the first frame update
    void Start()
    {
        SetStat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetStat()
    {
        status.MaxHP = status.LV * 10 + status.AddMaxHP;
        status.MaxMP = status.LV * 10 + status.AddMaxMP;
        status.ATK = status.LV * 1 + status.AddATK;
        status.MAT = status.LV * 1 + status.AddMAT;
        status.HP = status.MaxHP;
        status.MP = status.MaxMP;
    }
    public void LVup()
    {
        status.LV++;
        SetStat();
    }

    public void getDamage(float damage)
    {
        
        status.HP -= damage;
        if (status.HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
