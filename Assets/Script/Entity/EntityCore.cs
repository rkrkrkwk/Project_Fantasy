using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCore : MonoBehaviour
{
    private EntityData entityData;
    [SerializeField] private GameObject dropItem;
    private EntityStatus entityStatus;
    public void init(int id)
    {
        entityStatus = GetComponent<EntityStatus>();
        entityData = EntityDatabase.instance.GetEntityData(id);
        GetComponent<NavAgent2DModifier>().init();
        GetComponent<Animator>().runtimeAnimatorController = entityData.animatorController;
    }
    public float getSpeed() {return entityData.speed;}
    public int getId() {return entityData.ID;}
    public StatSet getStatus() {return entityData.stat;}
    public void getDamage(float damage)
    {
        entityStatus.getDamage(damage);
    }
    public void Dead() {DropItem(); giveExp(); Destroy(this.gameObject);}
    public void DropItem()
    {
        foreach (ItemTable item in entityData.itemTables)
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
    public void giveExp()
    {
        PlayerManager.instance.GetExp(entityData.exp);
    }
}
