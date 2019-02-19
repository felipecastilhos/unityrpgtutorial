using UnityEngine;
using System.Collections;


[CreateAssetMenu(fileName ="BasicInfo", menuName ="BasicInfo")]
public class BaseInfo : ScriptableObject {
    public int levelBase;
    public int hpBase;
    public int manaBase;
    public int strenght;
    public int agility;
    public int attackBase;
    public int defenseBase;
}