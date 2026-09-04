using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSet : MonoBehaviour
{
    [SerializeField] private GameObject status;
    [SerializeField] private GameObject skill;
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject equipment;

    private void OnEnable()
    {
        Debug.Log("Active MenuSet");
        status.SetActive(true);
        skill.SetActive(false);
        equipment.SetActive(true);
        inventory.SetActive(true);
        UiEventController.Instance.InventoryOpen += OpenInventory;
        UiEventController.Instance.SkillOpen += OpenSkill;
        Debug.Log("Menu init");
    }
    private void OnDisable()
    {
        UiEventController.Instance.InventoryOpen -= OpenInventory;
        UiEventController.Instance.SkillOpen -= OpenSkill;
    }
    public void OpenInventory()
    {
        Debug.Log("Open Inventory");
        status.SetActive(true);
        skill.SetActive(false);
        equipment.SetActive(true);
        inventory.SetActive(true);
    }
    public void OpenSkill()
    {
        Debug.Log("Skill Activate");
        status.SetActive(true);
        skill.SetActive(true);
        equipment.SetActive(false);
        inventory.SetActive(false);
        Debug.Log("Skill Activated");
    }
}
