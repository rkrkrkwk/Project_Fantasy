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
    public TextMeshProUGUI TMAT;

    void UpdateStatus(statStruct status)
    {
        TLV.text = status.LV.ToString();
        THP.text = status.MaxHP.ToString() + (status.AddMaxHP != 0 ? "+" + "(" + status.AddMaxHP.ToString() + ")" : "") + " / " + status.HP.ToString();
        TMP.text = status.MaxMP.ToString() + (status.AddMaxMP != 0 ? "+" + "(" + status.AddMaxMP.ToString() + ")" : "") + " / " + status.MP.ToString();
        TATK.text = status.ATK.ToString() + (status.AddATK != 0 ? "+" + "(" + status.AddATK.ToString() + ")" : "");
        TMAT.text = status.MAT.ToString() + (status.AddMAT != 0 ? "+" + "(" + status.AddMAT.ToString() + ")" : "");
    }
    public void Awake()
    {
        player = GameObject.FindWithTag("Player");
        playerStatus = player.GetComponent<Status>();
    }
    public void Start()
    {
        
    }
    public void Update()
    {
        UpdateStatus(playerStatus.status);
    }
}
