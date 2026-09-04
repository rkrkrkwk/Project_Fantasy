using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;
    private float angle;
    private Vector3 mousePosition;
    private Vector2 lookDirection;
    public float getAngle(){
        return this.angle;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = mousePosition - transform.position;
        angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        if (Mathf.Abs(angle) > 90)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void FixedUpdate() {
        Vector2 normalizedMovement = movement.normalized;
        rb.MovePosition(rb.position + normalizedMovement * moveSpeed * Time.fixedDeltaTime);
    }
}
