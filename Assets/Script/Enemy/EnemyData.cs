using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Character/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public int ID;
    public GameObject prefab;
    public float speed;
    public StatSet stat;
    public List<ItemTable> itemTables;
    public float exp;
}
