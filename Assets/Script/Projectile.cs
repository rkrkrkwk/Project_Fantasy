using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
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
        transform.position += transform.right * skill.speed * Time.deltaTime;
        if (Vector3.Distance(startPos, transform.position) > skill.range) Destroy(gameObject);
    }
    public void SetSkill(SkillData skillData, string targetTag)
    {
        skill = skillData as ProjectileData;
        this.targetTag = targetTag;
        if (skill == null) return;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Status status = collision.gameObject.GetComponent<Status>();
            status.getDamage(skill.CalculateDamage(status));
            pierceCount += 1;
            if (pierceCount >= skill.pierce)
            {
                Destroy(gameObject);
            }
        }
    }
}
