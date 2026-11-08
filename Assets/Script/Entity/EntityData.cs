using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Character/EntityData", order = 1)]
public class EntityData : ScriptableObject
{
    public int ID;
    public float speed;
    public StatSet stat;
    public List<ItemTable> itemTables;
    public float exp;
    public RuntimeAnimatorController animatorController;
}
