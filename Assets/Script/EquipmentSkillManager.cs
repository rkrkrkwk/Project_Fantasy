using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSkillManager : MonoBehaviour
{
    [SerializeField] private Skill playerSkill;
    [SerializeField] private Equipment equipment;
    public static EquipmentSkillManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SettingSkill()
    {
        List<int> list = equipment.GetEquipmentList();
        foreach (int id in list)
        {
            ItemList.Instance.GetItem(id);
        }
    }
}
