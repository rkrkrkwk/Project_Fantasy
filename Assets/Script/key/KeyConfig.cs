using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class KeyConfig : MonoBehaviour
{
    public class KeyConfigDataJson
    {
        public SkillSlot[] actions;
        public KeyCode[] keys;
    }
    private KeyConfigDataJson data = new KeyConfigDataJson();
    
    public SkillSlot[] getActions() { return data.actions; }
    public KeyCode[] getKeys() { return data.keys; }

    private string filePath = "Data/KeyConfig";
    private Dictionary<SkillSlot, KeyCode> KeySetting = new Dictionary<SkillSlot, KeyCode>();
    public IReadOnlyDictionary<SkillSlot, KeyCode> GetKeyConfig() { return KeySetting; }

    void Start()
    {
        if (Resources.Load<TextAsset>(filePath) == null)
        {
            Debug.LogError("KeyConfig file not found");
        }
        else
        {
            TextAsset textAsset = Resources.Load<TextAsset>(filePath);
            string json = textAsset.text;
            data = JsonUtility.FromJson<KeyConfigDataJson>(json);
            foreach (SkillSlot action in data.actions)
            {
                KeySetting.Add(action, data.keys[Array.IndexOf(data.actions, action)]);
            }
            if (KeySetting.Count == 0)
            {
                Debug.LogError("KeyConfig file is empty");
            }
            else
            {
                Debug.Log(KeySetting.Count + " KeyConfig file loaded");
            }
        }
    }
}
