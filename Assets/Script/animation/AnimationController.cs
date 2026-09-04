using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EntityMovementsManager entityMovementsManager;
    private AnimationType animationType = AnimationType.Idle;
    private void Update()
    {
        if(animationType != entityMovementsManager.getAnimationType())
        {
            animationType = entityMovementsManager.getAnimationType();
            animator.SetInteger("moves", (int)animationType);
        }
    }
}
