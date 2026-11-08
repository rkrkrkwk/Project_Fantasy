using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLimitManager : MonoBehaviour
{
    public static ObjectLimitManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public Dictionary<int, int> objectCount = new Dictionary<int, int>(); // object id, count
    
    public bool CheckObjectCount(int id)
    {
        if(SkillDatabase.Instance.GetSkillData(id).objectLimit <= 0)
        {
            Debug.Log("No object limit for skill id: " + id);
            return false;
        }
        Debug.Log("Checking object count for skill id: " + id);
        if(objectCount.ContainsKey(id))
        {
            Debug.Log("Current count for skill id " + id + ": " + objectCount[id]);
            if(objectCount[id] >= SkillDatabase.Instance.GetSkillData(id).objectLimit)
            {
                Debug.Log("Object limit reached for skill id: " + id);
                return true;
            }
            else
            {
                objectCount[id]++;
                Debug.Log("Incremented object count for skill id " + id + ". New count: " + objectCount[id]);
                return false;
            }
        }
        else
        {
            Debug.Log("Adding skill id " + id + " to object count dictionary.");
            objectCount.Add(SkillDatabase.Instance.GetSkillData(id).skillId, 1);
            return false;
        }
    }

    public void ObjectRelease(int id)
    {
        objectCount[id]--;
    }
}
