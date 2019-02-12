using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Portal : MonoBehaviour {
    [SerializeField] private Transform target;
    [SerializeField] private Tilemap targeTilemap;


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("hero"))
        {
            Debug.Log("Teleporting hero to teleport: " + target.name);
            Debug.Log("Teleporting hero to tilemap: " + targeTilemap.name);
            Debug.Log("Hero current z: " + collision.transform.position.z);
            collision.transform.position = target.GetChild(0).transform.position;
            Debug.Log("Hero Teleport to z: " + target.GetChild(0).transform.position.z);
            TargetCamera.instance.tileMap = targeTilemap;
            TargetCamera.instance.StartMap();
        }
    }
}
