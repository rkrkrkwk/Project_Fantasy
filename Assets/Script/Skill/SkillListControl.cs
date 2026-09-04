using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillListControl : MonoBehaviour
{
    public void ClearList()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
