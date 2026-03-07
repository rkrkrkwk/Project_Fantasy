using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    GameObject player;
    Status playerStatus;
    public TextMeshProUGUI TLV;
    public TextMeshProUGUI THP;
    public TextMeshProUGUI TMP;
    public TextMeshProUGUI TATK;
    public TextMeshProUGUI TDEF;

    public void UpdateStatus(Status status)
    {
        StatStruct stat = status.stat;
        TLV.text = status.level.ToString();
        THP.text = stat.MaxHP.basic.ToString() + (stat.MaxHP.modifier != 0 ? "+(" + stat.MaxHP.modifier.ToString() + ")" : "") + " / " + status.hp.ToString();
        TMP.text = stat.MaxMP.basic.ToString() + (stat.MaxMP.modifier != 0 ? "+(" + stat.MaxMP.modifier.ToString() + ")" : "") + " / " + status.mp.ToString();
        TATK.text = stat.ATK.basic.ToString() + (stat.ATK.modifier != 0 ? "+(" + stat.ATK.modifier.ToString() + ")" : "");
        TDEF.text = stat.DEF.basic.ToString() + (stat.DEF.modifier != 0 ? "+(" + stat.DEF.modifier.ToString() + ")" : "");
    }
    public void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerStatus = player.GetComponent<Status>();
    }
    public void OnEnable()
    {
        UpdateStatus(playerStatus);
    }
}
