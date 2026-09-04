using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDatabase
{
    public static EnemyDatabase instance = new EnemyDatabase();
    private List<EnemyData> enemyList = new List<EnemyData>();
    private Dictionary<int, EnemyData> enemyLookup = new Dictionary<int, EnemyData>();
    public IReadOnlyDictionary<int, EnemyData> EnemyLookup => enemyLookup;
    public EnemyDatabase()
    {
        init();
    }
    public void clear()
    {
        enemyList.Clear();
        enemyLookup.Clear();
    }
    public void init()
    {
        clear();
        EnemyData[] List = Resources.LoadAll<EnemyData>("Enemy");
        if (List.Length == 0)return;
        foreach (EnemyData data in List)
        {
            if (enemyList.Exists(x => x.ID == data.ID))
            {
                Debug.LogWarning($"Duplicate enemy ID detected: {data.ID} for enemy {data.name}. Skipping this enemy.");
                continue;
            }
            else
            {
                enemyList.Add(data);
                enemyLookup[data.ID] = data;
            }
        }
    }
}
