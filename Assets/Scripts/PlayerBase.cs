using UnityEngine;
using System.Collections;

public abstract class PlayerBase : MonoBehaviour {
    public int levelBase;
    public BaseStatsJob baseStatsJob;

    public void Start() {
        levelBase = 1;
    }
}
