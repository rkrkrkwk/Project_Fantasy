using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Slash : MonoBehaviour
{
    private SlashData slashData;
    private Vector3 targetPosition;
    private bool clock = false;
    private bool reverse = false;
    private float currentAngle = 0;
    private float endAngle = 0;
    private Vector3 basePosition;
    private Transform caster;

    private void Update()
    {
        basePosition = caster.position;
        if(clock)
        {
            movetoCircle(currentAngle -= slashData.movespeed * Time.deltaTime);
            if(currentAngle <= endAngle)
            {
                RemoveSkill();
            }
        }
        else if(reverse)
        {
            movetoCircle(currentAngle += slashData.movespeed * Time.deltaTime);
            if(currentAngle >= endAngle)
            {
                RemoveSkill();
            }
        }
    }

    public void SetSkill(SlashData skillData, Vector3 mousePosition, Transform caster)
    {
        slashData = skillData;
        targetPosition = mousePosition;
        this.caster = caster;
        Init();
    }
    
    private void Init()
    {
        Vector3 vector3 = targetPosition - transform.position;
        Vector3 normalizedTarget = vector3.normalized;
        float angle = Mathf.Atan2(-normalizedTarget.x, normalizedTarget.y) * Mathf.Rad2Deg;
        movetoCircle(angle + slashData.startAngle);
        transform.localScale = new Vector3(slashData.size/5, slashData.size, 0);
        if(slashData.startAngle > 0)
        {
            clock = true;
        }
        else if(slashData.startAngle == 0)
        {
            int random = UnityEngine.Random.Range(0,2);
            if(random == 0)
            {
                clock = true;
            }
            else
            {
                reverse = true;
            }
        }
        else {
            reverse = true;
        }
        currentAngle = angle + slashData.startAngle;
        endAngle = angle + slashData.endAngle;
    }
    private void movetoCircle(float angle)
    {
        float radius = slashData.size/2;
        float radian = angle * Mathf.Deg2Rad;
        float y = radius * Mathf.Cos(radian);
        float x = radius * Mathf.Sin(radian);
        transform.position = basePosition + new Vector3(-x, y, 0);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EntityCore>().getDamage(slashData.getDamage(caster.GetComponent<PlayerStatusManager>().PlayerStats));
        }
    }
    public void RemoveSkill()
    {
        ObjectLimitManager.instance.ObjectRelease(slashData.skillId);
        Destroy(gameObject);
    }
}
