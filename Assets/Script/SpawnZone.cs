using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    private Spawner spawner;
    private int enemies = 0;
    private int enemyId;
    private void Awake()
    {
        spawner = transform.parent.GetComponent<Spawner>();
    }
    private void Start()
    {
        enemyId = EnemyDatabase.instance.EnemyLookup[spawner.getEID()].ID;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<EnemyCore>().getId() == enemyId) enemies++;
        if (enemies >= spawner.getMaxEnemies()) spawner.setFull();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && collision.gameObject.GetComponent<EnemyCore>().getId() == enemyId) enemies--;
        if (enemies < spawner.getMaxEnemies()) spawner.setNotFull();
    }
}
