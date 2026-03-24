using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool ChaseState = false;
    private bool AttackState = false;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed;
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 5)
        {
            ChaseState = true;
        }
        else
        {
            ChaseState = false;
        }
        if (ChaseState)
        {
            Chase();
        }
        if (Vector2.Distance(transform.position, player.transform.position) < 2)
        {
            AttackState = true;
        }
        else
        {
            AttackState = false;
        }
        if (AttackState)
        {
            InvokeRepeating("Attack", 0.5f, 0.5f);
        }
    }
    public void Chase()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, player.transform.position - transform.position), 0.1f);
        transform.position += (player.transform.position - transform.position).normalized * speed * Time.deltaTime;
    }
    public void Attack()
    {
        GameObject Attack = Instantiate(SkillDatabase.Instance.GetSkillData(1).prefab, transform.position, transform.rotation * Quaternion.Euler(0, 0, 90));
        Attack.GetComponent<Projectile>().SetSkill(SkillDatabase.Instance.GetSkillData(1), "Player");
        CancelInvoke();
    }
}
