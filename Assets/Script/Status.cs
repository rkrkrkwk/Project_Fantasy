using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public float HP;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetDamage(float damage)
    {
        HP = HP - damage;
        if (HP<=0){ Destroy(gameObject); }
    }
}
