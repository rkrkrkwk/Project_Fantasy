using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using System.Linq;

public class PlayerStatusManager : MonoBehaviour
{
    private StatStruct basicStats;
    private List<StatStruct> itemStats;
    private StatStruct skillStats;
    private StatStruct playerStats;
    public StatStruct PlayerStats { get { return playerStats; } }
    private int level;
    public int Level { get { return level; } }
    private float exp;
    public int Exp { get { return (int)exp; } }
    private int INV;
    public int Inv { get { return INV; } }
    private float HP;
    public int hp { get { return (int)HP; } }
    private void Start()
    {
        init();
    }
    private void init()
    {
        basicStats = new StatStruct(new float[] {10, 1, 1, 3});
        level = 1;
        INV = 3;
        itemStats = new List<StatStruct>();
        foreach(EquipmentType type in Enum.GetValues(typeof(EquipmentType)))
        {
            itemStats.Add(new StatStruct());
        }
        skillStats = new StatStruct();
        refreshStats();
        HP = playerStats.getStat(StatType.MaxHP);
    }
    private void refreshStats()
    {
        StatStruct itemStat = new StatStruct();
        foreach (EquipmentType type in Enum.GetValues(typeof(EquipmentType)))
        {
            itemStat = itemStat + itemStats[(int)type];
        }
        playerStats = basicStats + itemStat + skillStats;
    }
    public void itemStatChange(EquipmentType type, StatStruct statStruct)
    {
        String debug = "";
        foreach(StatStruct stat in itemStats)
        {
            foreach(StatType statType in Enum.GetValues(typeof(StatType)))
            {
                debug += stat.getStat(statType) + " ";
            }
        }
        Debug.Log(debug);
        itemStats[(int)type] = statStruct;
        refreshStats();
    }
    public void itemStatRemove(EquipmentType type)
    {
        itemStats[(int)type] = new StatStruct();
        refreshStats();
    }
    public void skillStatChange(StatStruct statStruct)
    {
        skillStats = statStruct;
        refreshStats();
    }
    public void levelUp()
    {
        level += 1;
        refreshStats();
        HP = playerStats.getStat(StatType.MaxHP);
    }
    public void Heal(float heal)
    {
        HP += heal;
        if (HP > playerStats.StatDict[StatType.MaxHP].getFinal())
        {
            HP = playerStats.StatDict[StatType.MaxHP].getFinal();
        }
    }
}
