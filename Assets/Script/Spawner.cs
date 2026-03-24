using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private int EID;
    [SerializeField]
    private float respawnTime;
    private bool isFull = false;
    [SerializeField]
    private int maxEnemies;
    public void spawnEnemy()
    {
        if (!isFull)
        {
            StartCoroutine(spawnEnemyDelay());
        }
    }
    public IEnumerator spawnEnemyDelay()
    {
        yield return new WaitForSeconds(respawnTime);
        Instantiate(EnemyDatabase.instance.EnemyLookup[EID].prefab, new Vector3(Random.value * transform.localScale.x, Random.value * transform.localScale.y, 1), transform.rotation);
    }
    public void setFull()
    {
        isFull = true;
    }
    public void setNotFull()
    {
        isFull = false;
    }
    public int getMaxEnemies()
    {
        return maxEnemies;
    }
}
