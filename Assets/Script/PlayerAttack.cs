using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject attackObject;
    private Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            playerPos = GameObject.Find("Player").GetComponent<Transform>();
            Instantiate(attackObject, playerPos.position, playerPos.rotation);
        }
    }
}
