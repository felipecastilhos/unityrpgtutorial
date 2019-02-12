using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TargetCamera : MonoBehaviour {
    public Transform target;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    [SerializeField] public Tilemap tileMap;
    private Vector3 minTile;
    private Vector3 maxTile;


    public static TargetCamera instance;


    private void Awake() {
        if(instance == null) { 
            instance = this;
        }
    }

    void Start() {
        Debug.Log("Start at: " + tileMap.name);
        StartMap();
    }

    public  void StartMap() {
        Debug.Log("Iniciando tilemap: " + tileMap.name);
        loadTileValues();
        Bounds(minTile, maxTile);
    }

    void LateUpdate() {
        float xPosition = Mathf.Clamp(target.position.x, xMin, xMax);
        float yPosition = Mathf.Clamp(target.position.y, yMin, yMax);
        float zPosition = -10;
        transform.position = new Vector3(xPosition, yPosition, zPosition);
    }

    private void loadTileValues() {
        minTile = tileMap.CellToWorld(tileMap.cellBounds.min);
        maxTile = tileMap.CellToWorld(tileMap.cellBounds.max);
    }

    void Bounds(Vector3 minTile, Vector3 maxTile) {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        xMin = minTile.x + width / 2;
        xMax = maxTile.x - width / 2;

        yMin = minTile.y + height / 2;
        yMax = maxTile.y - height / 2;
    }
}
