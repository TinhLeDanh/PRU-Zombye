using UnityEngine;

public class DamageableEntity : BaseGameEntity
{
    [SerializeField] private HealthHUD _healthbar;
    public GameObject floatingPoint;

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
        int realDamage = damage - characterData.GetArmor();

        if(_currentHealth - realDamage <= 0)
            realDamage = (int)_currentHealth;

        _currentHealth -= realDamage;

        GameObject textMeshGO = Instantiate(floatingPoint, transform.position, Quaternion.identity);

        textMeshGO.GetComponentInChildren<TextMesh>().text = realDamage.ToString();
        Destroy(textMeshGO, 1f);

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
        if(this is BasePlayerCharacterEntity player)
        {
            _maxHealth = characterData.GetHealth(player.levelSystem.level);
        }
        else if (this is MonsterCharacterEntity character)
        {
            _maxHealth = characterData.GetHealth(WaveManager.instance.currentWave);
        }
        _currentHealth = _maxHealth;
    }

    public virtual void OnDead()
    {
        Movement.MovementState = MovementState.Dead;
        AudioManager.Play(AudioClipName.Explosion);
    }
}