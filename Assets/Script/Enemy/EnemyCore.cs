using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCore : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private GameObject dropItem;

    public float getSpeed() {return enemyData.speed;}
    public float getId() {return enemyData.ID;}
    public StatSet getStatus() {return enemyData.stat;}
    public void Dead() {DropItem(); Destroy(this.gameObject);}
    public void DropItem()
    {
        foreach (ItemTable item in enemyData.itemTables)
        {
            float randomValue = Random.Range(0f, 1f);
            if (randomValue <= item.probability)
            {
                GameObject droppedItem = Instantiate(dropItem, transform.position, Quaternion.identity);
                DroppedItem droppedItemScript = droppedItem.GetComponent<DroppedItem>();
                droppedItemScript.init(item.id, 1);
            }
        }
        
    }
}
