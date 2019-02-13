using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Destructable : MonoBehaviour
{
    [SerializeField] Animator destructionAnimator;


    IEnumerator OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.CompareTag("heroAttack"))
        {
        Debug.Log("start breaking animation");
            destructionAnimator.Play("Breaking");
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
    
        }

    }
}
