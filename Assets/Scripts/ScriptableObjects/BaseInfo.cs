using UnityEngine;
using System.Collections;

[System.Serializable]
public class BaseStatsJob {
    public int hpBase;
    public int manaBase;
    public int strenght;
    public int agility;
    public int attackBase;
    public int defenseBase;
}


[CreateAssetMenu(fileName ="BasicInfo", menuName ="BasicInfo")]
public class BaseInfo : ScriptableObject {
    public int levelBase;
    public BaseStatsJob baseInfoJob;
}