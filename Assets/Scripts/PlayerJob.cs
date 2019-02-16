using UnityEngine;
using System.Collections;


public enum Job {
    WARRIOR,
    HUNTER
}

public class PlayerJob : PlayerBase {

    public Job job;



    // Use this for initialization
    void Start() {
        levelBase = 1;
        hpBase = 100;

    }

    // Update is called once per frame
    void Update() {

    }
}
