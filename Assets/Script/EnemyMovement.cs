using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public Transform playerPos;
    private Vector3 target;
    bool PlayerPosCheck(Transform playerPos)
    {
        if (Vector3.Distance(playerPos.position, transform.position) < 10) return true;
        else return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPosCheck(playerPos)) { target = playerPos.position; }
        transform.position = Vector3.MoveTowards(transform.position, target, movespeed * Time.deltaTime);
    }
}
