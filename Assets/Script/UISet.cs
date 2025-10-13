using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISet : MonoBehaviour
{
    public GameObject Status;
    public GameObject Inventory;
    // Start is called before the first frame update
    void Start()
    {
        Status.SetActive(false);
        Inventory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Status.SetActive(!Status.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(!Inventory.activeSelf);
        }
    }
}
