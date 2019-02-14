using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destructable : MonoBehaviour
{
    [SerializeField] Animator destructionAnimator;

    IEnumerator OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("heroAttack")) {
            Debug.Log("Breaking pot");
            destructionAnimator.Play("Breaking");
            CoinSpawn.instance.Spawn(transform.position);
            yield return new WaitForSeconds(0.5f);
            Destroy(gameObject);
    
        }

    }
}
