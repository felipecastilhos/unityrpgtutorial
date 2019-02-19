using UnityEngine;
using System.Collections;


public enum Job {
    Warrior = 0,
    Hunter = 1
}

public class PlayerJob : PlayerBase {

    public Job job;

    // Use this for initialization
    new void Start() {
        base.Start();
        PlayerStats playerStats = PlayerStats.instance;
        playerStats.SetJob(Job.Warrior);
        job = playerStats.GetJob();

        BaseInfo basicInfo = PlayerStats.instance.GetBaseInfo(job);

        hpBase = basicInfo.hpBase;
        manaBase = basicInfo.manaBase;
        strenght = basicInfo.strenght;
        agility = basicInfo.agility;
        defenseBase = basicInfo.defenseBase;
        attackBase = basicInfo.attackBase;
        
    }

    // Update is called once per frame
    void Update() {

    }
}
