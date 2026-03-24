using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Character/EnemyData", order = 1)]
public class EnemyData : ScriptableObject
{
    public int EID;
    public GameObject prefab;
    public StatStruct stat;
    public float speed;
    public int skill;
}
