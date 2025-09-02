using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float angle;
    private Vector3 mousePosition;
    private Vector2 lookDirection;
    private float smoothedAngle;
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = mousePosition - transform.position;
        angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        smoothedAngle = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * Time.deltaTime);
        rb.rotation = smoothedAngle;
    }

    void FixedUpdate() {
        Vector2 normalizedMovement = movement.normalized;
        rb.MovePosition(rb.position + normalizedMovement * moveSpeed * Time.fixedDeltaTime);
    }
}
