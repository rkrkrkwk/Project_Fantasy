using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField]
    private Transform playerPos;
    private Vector3 target;
    bool PlayerPosCheck(Transform playerPos)
    {
        if (Vector3.Distance(playerPos.position, transform.position) < 10) return true;
        else return false;
    }
    void Start()
    {
        target = transform.position;
    }
    void Update()
    {
        if (PlayerPosCheck(playerPos)) { target = playerPos.position; }
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }
}
