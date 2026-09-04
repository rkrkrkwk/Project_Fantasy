using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntityMovementsManager : MonoBehaviour
{
    [System.Serializable]
    public struct EntityPatternStruct
    {
        public EntityPattern pattern;
        public EntityMovement movement;
    }
    private AnimationType animationType = AnimationType.Idle;
    private EntityPattern currentPattern = EntityPattern.normal;
    [SerializeField] private List<EntityPatternStruct> entityMovements = new List<EntityPatternStruct>();
    private Dictionary<EntityPattern, EntityMovement> entityMovementDictionary = new Dictionary<EntityPattern, EntityMovement>();
    private void Start()
    {
        foreach (EntityPatternStruct pattern in entityMovements)
        {
            entityMovementDictionary.Add(pattern.pattern, pattern.movement);
        }
    }
    private void Update()
    {
        animationType = entityMovementDictionary[currentPattern].getAnimationType();
        if(currentPattern == EntityPattern.normal && entityMovementDictionary[EntityPattern.normal].enabled == false)
        {
            foreach(EntityMovement movement in entityMovementDictionary.Values)
            {
                movement.enabled = false;
            }
            entityMovementDictionary[currentPattern].enabled = true;
        }
    }
    public AnimationType getAnimationType()
    {
        return animationType;
    }
}
