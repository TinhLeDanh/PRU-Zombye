using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackFeedback : MonoBehaviour
{
    private Rigidbody2D rb;
    public UnityEvent OnBegin, OnDone;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlayFeedback(float force, float delay, Vector2 direction)
    {
        StopAllCoroutines();
        OnBegin?.Invoke();

        direction = direction.normalized;

        rb.AddForce(direction * force, ForceMode2D.Impulse);
        StartCoroutine(ResetCO(delay));
    }

    private IEnumerator ResetCO(float delay)
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        OnDone?.Invoke();
    }
}
