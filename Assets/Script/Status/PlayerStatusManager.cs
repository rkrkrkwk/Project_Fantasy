using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusManager : MonoBehaviour
{
    private StatStruct basicStats;
    private StatStruct itemStats;
    private StatStruct skillStats;
    private StatStruct playerStats;
    public StatStruct PlayerStats { get { return playerStats; } }
    private int level;
    public int Level { get { return level; } }
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
        itemStats = new StatStruct();
        skillStats = new StatStruct();
        refreshStats();
        HP = playerStats.getStat(StatType.MaxHP);
    }
    private void refreshStats()
    {
        playerStats = basicStats + itemStats + skillStats;
    }
    public void itemStatChange(StatStruct statStruct)
    {
        itemStats = statStruct;
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
}
