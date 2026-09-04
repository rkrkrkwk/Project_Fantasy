using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStatus : MonoBehaviour
{
    private EnemyCore core;
    private StatStruct stat;
    private float hp;
    private void Start()
    {
        core = GetComponent<EnemyCore>();
        stat = new StatStruct(new float[] {core.getStatus().maxHP, core.getStatus().ATK, core.getStatus().DEF});
        hp = core.getStatus().maxHP;
        Debug.Log(gameObject.GetInstanceID() + " HP : " + hp);
    }
    public void getDamage(float damage)
    {
        Debug.Log(gameObject.GetInstanceID() + " has been hit for " + damage + " damage" + " HP : " + hp);
        hp -= damage;
        if (hp < 0) hp = 0;
        if (hp == 0) core.Dead();
    }
}
