using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SkillExcutor : MonoBehaviour
{
    public GameObject skillHolder0;
    private float timer0;
    private Quaternion direction;
    private Vector3 position;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer0 > 0){ timer0 -= Time.deltaTime;}
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (skillHolder0)
            {
                if (timer0 <= 0)
                {
                    position = transform.position;
                    direction = transform.rotation;
                    Instantiate(skillHolder0, position, direction).GetComponent<Script>().status = GetComponent<Status>().status;
                    timer0 = skillHolder0.GetComponent<Script>().cooltime;
                }
            }
            else
            {
                Debug.Log("Skill Holder is Empty");
            }
        }
    }
}
