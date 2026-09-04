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
    private Coroutine coroutine;
    public int getEID() { return EID; }
    private void Update()
    {
        spawnEnemy();
    }
    public void spawnEnemy()
    {
        if (!isFull && coroutine == null)
        {
            coroutine = StartCoroutine(spawnEnemyDelay());
        }
    }
    public IEnumerator spawnEnemyDelay()
    {
        Instantiate(EnemyDatabase.instance.EnemyLookup[EID].prefab, new Vector3(transform.position.x + Random.value * transform.localScale.x, transform.position.y + Random.value * transform.localScale.y, 1), transform.rotation);
        yield return new WaitForSeconds(respawnTime);
        coroutine = null;
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
