using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISet : MonoBehaviour
{
    [SerializeField]
    private GameObject Status;
    [SerializeField]
    private GameObject Inventory;
    [SerializeField]
    private GameObject EquipWindow;
    [SerializeField]
    private GameObject SkillWindow;
    [SerializeField]
    private GameObject Menu;
    // Start is called before the first frame update
    void Start()
    {
        Status.SetActive(false);
        Inventory.SetActive(false);
        EquipWindow.SetActive(false);
        SkillWindow.SetActive(false);
        Menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Status.SetActive(!Status.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            EquipWindow.SetActive(!EquipWindow.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SkillWindow.SetActive(!SkillWindow.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(!Menu.activeSelf);
        }
    }
}
