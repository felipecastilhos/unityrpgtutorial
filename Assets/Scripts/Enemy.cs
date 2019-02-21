using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float vel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        chase();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(isHero(other)) {
            print("I see you hero");
            target = other.transform;
        }

    }


    private void OnTriggerExit2D(Collider2D collision) {
        if (isHero(collision)) {
            print("Ill find yout");
            target = null;
        }
    }


    private bool isHero(Collider2D collider) {
        return collider.CompareTag("hero");
    }

    private void chase() {
        if(target != null) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, vel * Time.deltaTime);
        }
    }
}
