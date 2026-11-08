using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityDatabase
{
    public static EntityDatabase instance = new EntityDatabase();
    private List<EntityData> entityList = new List<EntityData>();
    public List<EntityData> EntityList { get { return entityList; } }
    private EntityDatabase()
    {
        init();
    }
    public void clear()
    {
        entityList.Clear();
    }
    public EntityData GetEntityData(int id)
    {
        if (entityList.Count == 0)
        {
            init();
            if (entityList.Count == 0)
            {
                Debug.LogError("EntityDatabase is empty");
                return null;
            }
        }
        return entityList.Find(x => x.ID == id);
    }
    public void init()
    {
        clear();
        EntityData[] List = Resources.LoadAll<EntityData>("Entity");
        if (List.Length == 0) return;
        foreach (EntityData data in List)
        {
            if (entityList.Exists(x => x.ID == data.ID))
            {
                continue;
            }
            else
            {
                entityList.Add(data);
            }
        }
    }
}
