using UnityEngine;

public class DamageableEntity : BaseGameEntity
{
    [SerializeField] private HealthHUD _healthbar;

    protected Character characterData;
    private float _currentHealth;
    private float _maxHealth;

    protected override void EntityStart()
    {
        base.EntityStart();

        if (data is Character newData)
            characterData = newData;

        _maxHealth = characterData.GetHealth();
        _currentHealth = _maxHealth;

        if (_healthbar != null)
            _healthbar.UpdateHealthBar(characterData.health, _currentHealth);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= (damage - characterData.GetArmor());

        // Hit
        // AudioManager.Play(AudioClipName.BurgerDamage);
        if (_healthbar != null)
        {
            _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
        }

        if (ModelController != null)
        {
            ModelController.OnHit();
        }
        
        // Dead
        if (_currentHealth <= 0)
        {
            OnDead();
            if (ModelController != null)
            {
                ModelController.OnDead();
            }

            Destroy(gameObject);
        }
    }
    
    public void IncreaseHealth(int level)
    {
        _maxHealth += Mathf.RoundToInt((_currentHealth * 0.01f) * ((100 - level) * 0.1f));
        _currentHealth = _maxHealth;
    }

    public virtual void OnDead()
    {
        Movement.MovementState = MovementState.Dead;
        AudioManager.Play(AudioClipName.Explosion);
    }
}