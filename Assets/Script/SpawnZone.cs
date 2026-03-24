using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField]
    private Spawner spawner;
    private List<GameObject> enemies = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !enemies.Contains(collision.gameObject))
        {
            enemies.Add(collision.gameObject);
        }
        if (enemies.Count >= spawner.getMaxEnemies())
        {
            spawner.setFull();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && enemies.Contains(collision.gameObject))
        {
            enemies.Remove(collision.gameObject);
        }
        if (enemies.Count < spawner.getMaxEnemies())
        {
            spawner.setNotFull();
        }
    }
}
