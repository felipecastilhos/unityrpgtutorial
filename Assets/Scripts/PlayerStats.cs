using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    public const string TAG_EXPERIENCE_CURRENT = "CurrentExperience";
    public const string TAG_LEVEL_CURRENT = "CurrentLevel";

    public static PlayerStats instance;

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
        if (Input.GetKey(KeyCode.F)) {
            AddExperience(100);
            txtXp.text = "XP: " + GetCurrentExperience();
            txtLevel.text = "Level: " + GetLevel();
            txtXpNextLevel.text = "Next Level: " + GetExperienceNextLevel();
        }
        if (Input.GetKey(KeyCode.R)) {
            PlayerPrefs.DeleteAll();
        }

    }

    public float GetCurrentExperience() {
        return PlayerPrefs.GetFloat(TAG_EXPERIENCE_CURRENT);
    }

    public void AddExperience(float experienceAdd) {
        float currentExperience = GetCurrentExperience();
        print("[Experience] current added: " + currentExperience);
        float experienceAdded = experienceAdd * experienceMultiplier;
        print("[Experience] experience added: " + experienceAdded);
        float newExperience = currentExperience + experienceAdded;
        print("[Experience] new experienced: " + newExperience);
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

}
