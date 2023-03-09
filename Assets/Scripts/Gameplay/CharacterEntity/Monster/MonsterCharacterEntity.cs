using UnityEngine;

public class MonsterCharacterEntity : BaseCharacterEntity
{
    [SerializeField] private float _maxHealth = 3;
    private float _currentHealth;
    [SerializeField] private HealthBarMonster _healthbar;

    public override void InitialRequiredComponents()
    {
        base.InitialRequiredComponents();

    }

    protected override void EntityStart()
    {
        base.EntityStart();

        target = GameInstance.instance.player;
        _currentHealth = _maxHealth;
        _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
    }

    private void OnMouseDown()
    {
        _currentHealth -= Random.Range(0.5f, 1.5f);
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _healthbar.UpdateHealthBar(_maxHealth, _currentHealth);
        }
    }
}
