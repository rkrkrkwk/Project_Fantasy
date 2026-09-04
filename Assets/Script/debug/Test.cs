using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Skill playerSkill;
    [SerializeField] private Inventory inventory;
    [SerializeField] private int skillId = 1;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            playerSkill.AddSkill(skillId);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("pressed 0");
            inventory.AddItem(1, 1);
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            inventory.AddItem(2, 1);
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            inventory.AddItem(3, 1);
        }
    }
}
