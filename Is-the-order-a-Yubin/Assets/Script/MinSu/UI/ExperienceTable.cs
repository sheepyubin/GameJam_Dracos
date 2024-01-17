using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ExperienceTable 
{
    private Dictionary<int, int> experienceTable;
    string _path= "Assets/Resources/Level.json";
    public ExperienceTable()
    {
        experienceTable = new Dictionary<int, int>();
        LoadExperienceTable();
    }

    private void LoadExperienceTable()
    {
        string path = _path;

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            experienceTable = JsonUtility.FromJson<Dictionary<int, int>>(json);
        }
        else
        {
            Debug.LogError("Experience table JSON file not found.");
        }
    }

    public int GetExperienceForLevel(int level)
    {
        if (experienceTable.ContainsKey(level))
        {
            return experienceTable[level];
        }
        return 0;
    }
}
