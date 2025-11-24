using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine.UIElements;
public class Status : MonoBehaviour
{
    public statStruct baseStat = new statStruct(0, 0, 0, 0, 1, 10, 10, 10, 10, 5, 5);
    public statStruct itemStat = new statStruct();
    public statStruct status = new statStruct();
    public Equipment equipment;
    void Awake()
    {
        equipment = gameObject.GetComponent<Equipment>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        calcStat();
    }
    public void getItemStat()
    {
        Item[] items = equipment.items;
        statStruct res = new statStruct();
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                res = res + items[i].stat;
            }
        }
        itemStat = res;
    }

    public void calcStat()
    {
        getItemStat();
        status = baseStat + itemStat;
    }

    public void LVUP()
    {
        baseStat.addStat(0,0,0,0,1,10,10,10,10,5,5);
    }

    public void getDamage(float damage)
    {
        baseStat.HP -= damage;
        if (baseStat.HP < 0)
        {
            Destroy(gameObject);
        }
    }
}
