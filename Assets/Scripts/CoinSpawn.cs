using UnityEngine;
using System.Collections;

public class CoinSpawn : MonoBehaviour {
    public GameObject coin;
    public static CoinSpawn instance;
    public int spawnChance = 0;

    private void Awake() {
        if (instance == null) instance = this;
    }

    public void Spawn(Vector3 pos) {
        spawnChance = Random.Range(0, 3);
        if(spawnChance == 1) {
            Debug.Log("Spawn chance: " + spawnChance);
            Instantiate(coin, pos, Quaternion.identity);
        }
    }
}
