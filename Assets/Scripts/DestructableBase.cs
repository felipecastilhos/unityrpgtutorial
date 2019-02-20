using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestructableBase : MonoBehaviour
{
    public int resistencyPoints;

    public void AddDamage(int damage) {
        resistencyPoints -= damage;

        if(resistencyPoints <= 0) {
            StartCoroutine(DoDestroy());
        }
    }

    public abstract IEnumerator DoDestroy();
    public abstract void Dead();
}
