using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class cheat : MonoBehaviour
{
    [SerializeField]
    private Item item;
    [SerializeField]
    private int skillId;
    [Flags]
    public enum cheatType
    {
        none = 0,
        skill = 1,
        item = 2,
    }
    [SerializeField]
    private cheatType type;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            switch (type)
            {
                case cheatType.item:
                    collider.GetComponent<Inventory>().AddItem(item.id, 1);
                    break;
                case cheatType.skill:
                    collider.GetComponent<Skill>().AddSkill(skillId);
                    break;
            }
            Debug.Log("Cheat has been activated");
        }
    }
}
