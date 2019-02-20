using UnityEngine;
using System.Collections;

public abstract class PlayerBase : DestructableBase {
    public int levelBase;
    public BaseStatsJob baseStatsJob;

    public void Start() {
        levelBase = 1;
    }


    public override IEnumerator DoDestroy() {
        print("You cannot destroy what was meant to be killed hahaha");
        return null;
    }

    public override void Dead() {
        print("stoy gordito e mortito");
    }
}
