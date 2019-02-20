using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestructableItem : DestructableBase
{
    [SerializeField] Animator destructionAnimator;

    IEnumerator OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("heroAttack")) {
            AddDamage(3);
        }
        yield return 0;
    }

    public override IEnumerator DoDestroy() {
        Debug.Log("Breaking pot");
        destructionAnimator.Play("Breaking");
        CoinSpawn.instance.Spawn(transform.position);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public override void Dead() {
        print("this object never dies hahaha");
    }
}
