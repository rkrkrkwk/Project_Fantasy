using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyListener : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private KeyConfig keyConfig;
    private IReadOnlyDictionary<SkillSlot, KeyCode> KeySetting;
    private void Start()
    {
        GeyKeySetting();
    }
    private void Update()
    {
        if (KeySetting.Count == 0)
        {
            Debug.LogError("KeyConfig file is empty");
            GeyKeySetting();
        }
        if (Input.anyKeyDown)
        {
            foreach (var key in KeySetting)
            {
                if (Input.GetKeyDown(KeySetting[key.Key]))
                {
                    Debug.Log("Key " + key.Key + " has been pressed");
                    SkillExecuteManger.Instance.ExecuteSkill(SkillSettingManager.Instance.getSkill((int)key.Key), "Enemy", player);
                }
            }
        }
    }

    private void GeyKeySetting()
    {
        KeySetting = keyConfig.GetKeyConfig();
    }
}
