using UnityEngine;

public class DamageableEntity : BaseGameEntity
{
    [SerializeField] private HealthHUD _healthbar;
    public GameObject floatingPoint;

    protected Character characterData;
    private float _currentHealth;
    private float _maxHealth;

    public int CurrentLevel
    {
        get
        {
            if (this is BasePlayerCharacterEntity player)
            {
                return player.levelSystem.level;
            }
            else
            {
                return WaveManager.instance.currentWave;
            }
        }
    }

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

    public void ApplyDamage(BaseGameEntity caster ,int damage)
    {
        //Deal Damage
        int realDamage = damage - characterData.GetArmor(CurrentLevel);

        if (_currentHealth - realDamage <= 0)
            realDamage = (int)_currentHealth;

        _currentHealth -= realDamage;

        GameObject textMeshDamage = Instantiate(floatingPoint, transform.position, Quaternion.identity);

        textMeshDamage.GetComponentInChildren<TextMesh>().text = realDamage.ToString();
        textMeshDamage.transform.parent = transform;

        Destroy(textMeshDamage, 1f);

        //Regen
        if (caster is DamageableEntity damageableCaster)
        {
            if (damageableCaster.characterData.GetRegenRate() > 0)
            {
                int regenHealth = (int)(realDamage * damageableCaster.characterData.GetRegenRate());

                damageableCaster.IncreaseHealth(regenHealth);
            }
        }

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

    public void IncreaseHealthByLevel(int level)
    {
        _maxHealth = characterData.GetHealth(CurrentLevel, (int)_maxHealth);
        _currentHealth = _maxHealth;
    }

    public void IncreaseHealth(int amount)
    {
        if(amount <= 0) return;

        _currentHealth = (_currentHealth + amount > _maxHealth)? _maxHealth : _currentHealth + amount;

        GameObject textMeshRegen =
                    Instantiate(floatingPoint,
                    //transform.position,
                    new Vector2(transform.position.x + 0.25f, transform.position.y + 0.25f),
                    Quaternion.identity);
        textMeshRegen.transform.parent = transform;

        textMeshRegen.GetComponentInChildren<TextMesh>().text = amount.ToString();
        textMeshRegen.GetComponentInChildren<TextMesh>().color = Color.green;
        Destroy(textMeshRegen, 1f);

    }

    public virtual void OnDead()
    {
        Movement.MovementState = MovementState.Dead;
        AudioManager.Play(AudioClipName.Explosion);
    }
}