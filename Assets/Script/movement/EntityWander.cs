using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityWander : EntityMovement
{
    private Vector2 target;
    private void Start()
    {
        target = transform.position;
        animationType = AnimationType.Move;
    }
    private void Update()
    {
        if (animationType == AnimationType.Move && moveTimer == null)
        {
            target = (Vector2)transform.position + Random.insideUnitCircle * 5;
            MoveTo(target);
            moveTimer = StartCoroutine(MoveCoroutine(2, AnimationType.Idle));
        }
        if (animationType == AnimationType.Idle && waitTimer == null)
        {
            target = transform.position;
            MoveTo(target);
            waitTimer = StartCoroutine(WaitCoroutine(2, AnimationType.Move));
        }
        if (animationType == AnimationType.Idle && waitTimer != null)
        {
            target = transform.position;
            MoveTo(target);
        }
        if ((Vector2)transform.position == target && moveTimer != null) 
        {
            StopCoroutine(moveTimer); 
            animationType = AnimationType.Idle; 
            moveTimer = null; 
        }
        if(target.x > transform.position.x && transform.localScale.x < 0)
        {
            transform.localScale *= new Vector2(-1, 1);
        }
        else if (target.x < transform.position.x && transform.localScale.x > 0)
        {
            transform.localScale *= new Vector2(-1, 1);
        }
    }
}
