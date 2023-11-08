using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animator animator;
    private void OnEnable()
    {
        StartCoroutine(TurnOffCollider());
        StartCoroutine(Disappear());
    }
    IEnumerator TurnOffCollider()
    {
        yield return new WaitForSeconds(.5f);

        GetComponent<CircleCollider2D>().enabled = false;
    }

    IEnumerator Disappear()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }
}
