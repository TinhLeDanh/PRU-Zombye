using UnityEngine;

public class DamageableEntity : BaseGameEntity
{
    [SerializeField] private HealthBarMonster _healthbar;

    protected Character characterData;
    private float _currentHealth;
    private float _maxHealth;

    protected override void EntityStart()
    {
        base.EntityStart();

        if (data is Character newData)
            characterData = newData;
        _maxHealth = characterData.health;
        _currentHealth = _maxHealth;

        if (_healthbar != null)
            _healthbar.UpdateHealthBar(characterData.health, _currentHealth);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        // Hit
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

            Destroy(gameObject, 5f);
        }
    }

    public virtual void OnDead()
    {
        Movement.MovementState = MovementState.Dead;
    }
}