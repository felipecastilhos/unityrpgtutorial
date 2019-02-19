using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class BaseInfoJob {
    public Job job;
    public BaseStatsJob baseInfo;
}

public class PlayerStats : MonoBehaviour {
    public const string TAG_EXPERIENCE_CURRENT = "CurrentExperience";
    public const string TAG_LEVEL_CURRENT = "CurrentLevel";
    public const string TAG_CHARACTER_JOB = "CharacterJob";

    public static PlayerStats instance;
    public List<BaseInfoJob> baseInfoJobs;

    public int experienceMultiplier = 2;
    public float experienceLevel = 100;
    private float experienceNextLevel = 0.0f;
    public float dificultyFactor = 1.8f;

    public Text txtXp,
                txtLevel,
                txtXpNextLevel;
    
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }


    // Use this for initialization
    void Start() {
        print(experienceNextLevel);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            AddExperience(100);
            txtXp.text = "XP: " + GetCurrentExperience();
            txtLevel.text = "Level: " + GetLevel();
            txtXpNextLevel.text = "Next Level: " + GetExperienceNextLevel();
        }
        if (Input.GetKeyDown(KeyCode.R)) {
            PlayerPrefs.DeleteAll();
        }
    }

    public float GetCurrentExperience() {
        return PlayerPrefs.GetFloat(TAG_EXPERIENCE_CURRENT);
    }

    public void AddExperience(float experienceAdd) {
        float currentExperience = GetCurrentExperience();
        float experienceAdded = experienceAdd * experienceMultiplier;
        float newExperience = currentExperience + experienceAdded;
        float nextLevel = GetExperienceNextLevel();

        while(newExperience >= nextLevel) {
            newExperience -= nextLevel;
            AddLevel();
        }

        PlayerPrefs.SetFloat(TAG_EXPERIENCE_CURRENT, currentExperience + newExperience);
    }

    //TODO: tem uma atribuicao nessa porra mesmo?
    public float GetExperienceNextLevel() {
        experienceNextLevel = experienceLevel * (GetLevel() + 1) * dificultyFactor;
        return experienceNextLevel;
    }
    public int GetLevel() {
        return PlayerPrefs.GetInt(TAG_LEVEL_CURRENT);
    }

    public void AddLevel() {
        int newLevel = GetLevel() + 1;
        PlayerPrefs.SetInt(TAG_LEVEL_CURRENT, newLevel);
    }


    public void SetJob(Job job) {
        PlayerPrefs.SetInt(TAG_CHARACTER_JOB, (int) job);
    }

    public Job GetJob() {
        int jobValue = PlayerPrefs.GetInt(TAG_CHARACTER_JOB);
        switch(jobValue) {
            case 1: 
                return Job.Hunter;
            default:
                return Job.Warrior;
        }
    }

 

    public BaseStatsJob GetBaseInfo(Job job) {

        foreach(BaseInfoJob infoJob in baseInfoJobs) {
            if (infoJob.job == job) return infoJob.baseInfo;
        }

        return baseInfoJobs[0].baseInfo;
    }
}
