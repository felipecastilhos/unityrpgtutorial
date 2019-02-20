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
        baseStatsJob = PlayerStats.instance.GetBaseInfo(job);
        resistencyPoints = baseStatsJob.hpBase;
    }

    // Update is called once per frame
    void Update() {

    }

    public void AddDamage(int damage) {
        base.AddDamage(damage);
        Dead();
    }
}
