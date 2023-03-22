using UnityEngine;
using UnityEngine.UI;

public class HealthBarMonster : HealthHUD
{

    public override void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _healthbarSprite.fillAmount = currentHealth / maxHealth;
    }
}