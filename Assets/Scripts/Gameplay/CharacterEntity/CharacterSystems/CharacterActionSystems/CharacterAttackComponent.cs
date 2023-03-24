using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttackComponent : BaseGameEntityComponent<BaseCharacterEntity>, ICharacterAttackComponent
{
    public LayerMask enemyLayer;

    protected Weapon weapon;
    protected AttackState attackState;
    protected Character characterData;
    private float timeCounter;
    List<BaseCharacterEntity> enemies = new List<BaseCharacterEntity>();

    public override void EntityAwake()
    {
        base.EntityAwake();

        if (Entity.data is Character data)
            characterData = data;
        weapon = characterData.currentWeapon;
        attackState = AttackState.None;
    }

    public override void EntityUpdate()
    {
        if (GameInstance.instance.state != GameInstance.GameState.StartGame)
        {
            return;
        }

        base.EntityUpdate();

        if(timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;
        }
        else
        {
            attackState = AttackState.None;
        }
    }

    public bool CanAttack()
    {
        return attackState == AttackState.None && Entity.Movement.MovementState != MovementState.Dead;
    }

    public void Attack()
    {
        BaseCharacterEntity target = GetNearestTarget();
        if(target != null)
        {
            if(Entity is BaseCharacterEntity character)
            {
                character.FaceTarget(target);
            }

            int damage = 0;

            if (Entity is BasePlayerCharacterEntity player)
            {
                damage = characterData.GetDamage(player.levelSystem.level);
            }
            else if (Entity is MonsterCharacterEntity monster)
            {
                damage = characterData.GetDamage(GameInstance.instance.waveManager.currentWave);
            }

            StartCoroutine(weapon.Apply(target, Entity, damage));
            attackState = AttackState.Attacking;
            AudioManager.Play(AudioClipName.BurgerShot);
            timeCounter = weapon.cooldown;
        }
    }

    private BaseCharacterEntity GetNearestTarget()
    {
        enemies.Clear();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f, enemyLayer);
        foreach (Collider2D collider in colliders)
        {
            if(LayermaskExtensions.Contains(enemyLayer, collider.gameObject))
            {
                BaseCharacterEntity character = collider.gameObject.GetComponent<BaseCharacterEntity>();
                if(character.Movement.MovementState != MovementState.Dead)
                {
                    enemies.Add(character);
                }
            }
        }

        if (enemies == null)
            return null;

        Vector2 nearestDistance = new Vector2(999, 999);
        BaseCharacterEntity nearestCharacter = null;
        foreach (BaseCharacterEntity character in enemies)
        {
            if (Vector2.Distance(Entity.transform.position, character.transform.position) <
                Vector2.Distance(Entity.transform.position, nearestDistance))
            {
                nearestDistance = character.transform.position;
                nearestCharacter = character;
            }
        }

        return nearestCharacter;
    }

    public void CancelAttack()
    {
        throw new NotImplementedException();
    }

    public void ClearAttackStates()
    {
        throw new NotImplementedException();
    }
}
