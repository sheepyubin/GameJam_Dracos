using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UIElements;

public class Character : Stats_box
{
    // Start is called before the first frame update
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public Stats Stats { get; private set; }
    private ExperienceTable experienceTable;
    //public Stats_box ability;
    public void Start()
    {
        experienceTable = new ExperienceTable();
    }
    //public Character(int level, int experience, Stats stats)
    //{
    //    Level = level;
    //    Experience = experience;
    //    Stats = stats;
    //    experienceTable = new ExperienceTable();
    //}

    public void GainExperience(int amount)
    {
        Debug.Log("XP받기 성공");
        Experience += amount;
        CheckForLevelUp();

    }

    private void CheckForLevelUp()
    {
        int requiredExperience = experienceTable.GetExperienceForLevel(Level + 1);
        if (Experience >= requiredExperience)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Level++;
        IncreaseStatsForLevelUp(); 
    }
}
