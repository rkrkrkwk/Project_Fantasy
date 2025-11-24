using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cheat : MonoBehaviour
{
    [SerializeField]
    private Item item;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Inventory>().AddItem(item);
            Debug.Log("Cheat item added");
        }
    }
}
