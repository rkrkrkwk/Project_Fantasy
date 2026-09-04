using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntityMovement : MonoBehaviour
{
    [SerializeField]protected NavMeshAgent agent;
    protected AnimationType animationType;
    protected Coroutine waitTimer;
    protected Coroutine moveTimer;
    protected IEnumerator WaitCoroutine(float time, AnimationType animationType)
    {
        yield return new WaitForSeconds(time);
        this.animationType = animationType;
        waitTimer = null;
    }
    protected IEnumerator MoveCoroutine(float time, AnimationType animationType)
    {
        yield return new WaitForSeconds(time);
        this.animationType = animationType;
        moveTimer = null;
    }
    protected void MoveTo(Vector2 position)
    {
        agent.SetDestination(position);
    }
    public AnimationType getAnimationType()
    {
        return animationType;
    }
}
