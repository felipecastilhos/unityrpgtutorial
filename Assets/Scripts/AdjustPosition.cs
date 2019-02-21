using UnityEngine;
using System.Collections;

public class AdjustPosition : MonoBehaviour {

    public bool mustAdjustPosition;
    [SerializeField]
    public SpriteRenderer spriteRenderer;



    // Use this for initialization
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer.sortingLayerName != null) {
            spriteRenderer.sortingLayerName = "adjustP";
            updateLayer();
        }
    }

    // Update is called once per frame
    void Update() {
        if(mustAdjustPosition) {
            if(spriteRenderer != null) {
                updateLayer();
            }
        }
    }

    private void updateLayer() {
        spriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y) * 100;
    }
}
