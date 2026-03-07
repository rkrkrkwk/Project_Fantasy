using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillDatabase", menuName = "Skill/SkillDatabase", order = 1)]
public class SkillDatabase : ScriptableObject
{
    private List<SkillData> skillList = new List<SkillData>();
    public IReadOnlyList<SkillData> SkillList => skillList;
    private Dictionary<int, SkillData> SkillLookup = new Dictionary<int, SkillData>();
    public IReadOnlyDictionary<int, SkillData> SkillLookupTable => SkillLookup;
    public static SkillDatabase Instance { get; private set; }
    public void Clear()
    {
        skillList.Clear();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitInstance()
    {
        Instance = Resources.Load<SkillDatabase>("SkillDatabase/SkillDatabase");
        Debug.Log(Instance);
        Instance.Init();
    }
    public void Init()
    {
        Clear();
        skillList = Resources.LoadAll<SkillData>("Skill").OrderBy(skill => skill.skillId).ToList();
        foreach (SkillData skill in skillList)
        {
            if (SkillLookup.ContainsKey(skill.skillId))
            {
                Debug.LogWarning($"Duplicate skill ID detected: {skill.skillId} for skill {skill.skillName}. Skipping this skill.");
                continue;
            }
            SkillLookup[skill.skillId] = skill;
        }
    }
    public SkillData GetSkillData(int id)
    {
        if(!SkillLookup.ContainsKey(id)) return null;
        return SkillLookup[id];
    }
}
