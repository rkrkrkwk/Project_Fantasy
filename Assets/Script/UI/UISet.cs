using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISet : MonoBehaviour
{
    private GameObject Menu;
    private GameObject Console;
    // Start is called before the first frame update
    private void Awake()
    {
        Menu = gameObject.transform.GetChild(0).gameObject;
        Console = gameObject.transform.GetChild(1).gameObject;
    }
    void Start()
    {
        Menu.SetActive(false);
        Console.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Debug.Log("GetKeyDown Tab");
            GamePause.Instance.TogglePause();
            Menu.SetActive(!Menu.activeSelf);
            Debug.Log("Menu Activate");
        }
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            GamePause.Instance.TogglePause();
            Console.SetActive(!Console.activeSelf);
        }
    }
}
