using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
     private SlashData slashData;
    private Vector3 targetPosition;

    public void SetSkill(SlashData skillData, Vector3 mousePosition)
    {
        slashData = skillData;
        targetPosition = mousePosition;
    }

}
