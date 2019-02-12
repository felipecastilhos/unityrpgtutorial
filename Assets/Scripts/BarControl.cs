 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BarControl : MonoBehaviour {

    private Image barImg; 

    // Start is called before the first frame update
    void Start() {
        barImg = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            barImg.fillAmount -= 0.1f * Time.deltaTime;
        }
        else if(barImg.fillAmount < 1) {
            barImg.fillAmount += 0.3f * Time.deltaTime;
        }
    }
}
