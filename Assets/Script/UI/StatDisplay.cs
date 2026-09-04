using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatDisplay : MonoBehaviour
{
    [SerializeField] private PlayerStatusManager playerStatus;
    [SerializeField] private TextMeshProUGUI TLV;
    [SerializeField] private TextMeshProUGUI THP;
    [SerializeField] private TextMeshProUGUI TATK;
    [SerializeField] private TextMeshProUGUI TDEF;

    public void UpdateStatus(PlayerStatusManager playerStatus)
    {
        StatStruct stat = playerStatus.PlayerStats;
        TLV.text = "LV : " + playerStatus.Level.ToString();
        THP.text = "HP : " + stat.getStat(StatType.MaxHP).ToString() + " / " + playerStatus.hp.ToString();
        TATK.text = "ATK : " + stat.getStat(StatType.ATK).ToString();
        TDEF.text = "DEF : " + stat.getStat(StatType.DEF).ToString();
    }
    public void OnEnable()
    {
        if(playerStatus.PlayerStats == null) return;
        UpdateStatus(playerStatus);
    }
}
