using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISet : MonoBehaviour
{
    public GameObject Status;
    public GameObject Inventory;
    public GameObject ItemChoicePanel;
    public GameObject EquipWindow;
    // Start is called before the first frame update
    void Start()
    {
        Status.SetActive(false);
        Inventory.SetActive(false);
        EquipWindow.SetActive(false);
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
    }
}
