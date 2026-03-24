using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using JetBrains.Annotations;
public class Status : MonoBehaviour
{
    private int Level;
    private StatStruct status = new StatStruct();
    private float HP;
    private float MP;
    public int level { get => Level; set => Level = value; }
    public StatStruct stat { get => status; set => status = value; }
    public float hp { get => HP; set => HP = value; }
    public float mp { get => MP; set => MP = value; }
    [SerializeField]
    private StatDisplay statDisplay;
    [SerializeField]
    private Equipment equipment;

    void Awake()
    {
        if (checkStatusFile())
        {
            Debug.Log("Status File exists");
            if (LoadStatus())
            {
                Debug.Log("Status has been loaded");
            }
            else
            {
                Debug.Log("Status has not been loaded");
            }
        }
        else
        {
            Debug.Log("Status File does not exist");
            init();
        }
    }
    
    private bool checkStatusFile()
    {
        //check file
        Debug.Log("Check Status File");
        return false;
    }

    private bool LoadStatus()
    {
        //load file
        Debug.Log("Load Status");
        return false;
    }

    private void init()
    {
        level = 1;
        status.MaxHP = new stat(10);
        status.MaxMP = new stat(10);
        status.ATK = new stat(1);
        status.DEF = new stat(1);
        HP = status.MaxHP.Final;
        MP = status.MaxMP.Final;
    }

    private void calcBasic()
    {
        status.MaxHP.basic = level * 10;
        status.MaxMP.basic = level * 10;
        status.ATK.basic = level;
        status.DEF.basic = level;
        calcAll();
    }

    public void calcModifier()
    {
        // get item, skill stat and calculated
        foreach (var item in equipment.Items.Values)
        {
            if (item != null)
            {
                stat += item.stat;
                Debug.Log("Item " + item.itemName + "status" + stat.MaxHP.modifier + "," + stat.MaxMP.modifier + "," + stat.ATK.modifier + "," + stat.DEF.modifier +  " has been acquired");
            }
        }
        Debug.Log("Modifier has been calculated");
        calcAll();
    }

    private void calcAll()
    {
        stat.calcAll();
        statDisplay.UpdateStatus(this);
    }

    public void getDamage(float damage)
    {
        HP -= damage;
        if (HP < 0) HP = 0;
        dead();
    }

    public void resetStatus()
    {
        status.reset(); 
        calcBasic();
        calcModifier();
    }

    public void dead()
    {
        if (gameObject.tag == "Player")
            gameObject.SetActive(false);
        else
            Destroy(gameObject);
    }
}
