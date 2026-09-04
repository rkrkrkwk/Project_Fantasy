using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private GameObject owner;
    private GameObject target;
    private string targetTag;
    private ProjectileData skill;
    private Vector3 startPos;
    private int pierceCount = 0;
    void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        if (skill == null) return;
        transform.position += transform.up * skill.speed * Time.deltaTime;
        if (Vector3.Distance(startPos, transform.position) > skill.range) Destroy(gameObject);
    }
    public void SetSkill(SkillData skillData, string targetTag, GameObject owner)
    {
        skill = skillData as ProjectileData;
        this.targetTag = targetTag;
        this.owner = owner;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger enter");
        if (collision.gameObject.CompareTag(targetTag))
        {
            EntityStatus status = collision.gameObject.GetComponent<EntityStatus>();
            status.getDamage(skill.CalculateDamage(owner.GetComponent<PlayerStatusManager>()));
            Debug.Log(owner.GetInstanceID() + " hit " + collision.gameObject.GetInstanceID() + " for " + skill.CalculateDamage(owner.GetComponent<PlayerStatusManager>()) + " damage");
            pierceCount += 1;
            if (pierceCount >= skill.pierce)
            {
                Destroy(gameObject);
            }
        }
    }
}
