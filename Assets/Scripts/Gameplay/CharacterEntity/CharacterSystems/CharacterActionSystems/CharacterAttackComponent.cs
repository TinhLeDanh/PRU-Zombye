using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class CharacterAttackComponent : BaseGameEntityComponent<BaseCharacterEntity>, ICharacterAttackComponent
{
    public LayerMask enemyLayer;

    protected Weapon weapon;
    protected AttackState attackState;
    protected Character characterData;
    private float timeCounter;

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
        return attackState == AttackState.None;
    }

    public void Attack()
    {
        MonsterCharacterEntity monster = GetNearestTarget();
        Debug.Log(monster);
        if(monster != null)
        {
            weapon.Apply(monster, Entity, characterData.currentWeapon.damage);
            attackState = AttackState.Attacking;
            timeCounter = weapon.cooldown;
        }
    }

    private MonsterCharacterEntity GetNearestTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 5f, enemyLayer);
        List<MonsterCharacterEntity> monsters = new List<MonsterCharacterEntity>();
        foreach (Collider2D collider in colliders)
        {
            if(LayermaskExtensions.Contains(enemyLayer, collider.gameObject))
            {
                monsters.Add(collider.gameObject.GetComponent<MonsterCharacterEntity>());
            }
        }

        if (monsters == null)
            return null;

        Vector2 nearestDistance = new Vector2(999, 999);
        MonsterCharacterEntity nearestMonster = monsters.First<MonsterCharacterEntity>();
        foreach (MonsterCharacterEntity monster in monsters)
        {
            if (Vector2.Distance(Entity.transform.position, monster.transform.position) <
                Vector2.Distance(Entity.transform.position, nearestDistance))
            {
                nearestDistance = monster.transform.position;
                nearestMonster = monster;
            }
        }

        return nearestMonster;
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
