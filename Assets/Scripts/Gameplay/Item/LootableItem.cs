using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class LootableItem : MonoBehaviour
{
    public LayerMask playerLayer;
    public int exp;

    public void SetupData(int exp)
    {
        this.exp = exp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayermaskExtensions.Contains(playerLayer, collision.gameObject))
        {
            LevelSystem.Instance.GainExperienceFlatRate(exp);
            Destroy(this.gameObject);
        }
    }
}
