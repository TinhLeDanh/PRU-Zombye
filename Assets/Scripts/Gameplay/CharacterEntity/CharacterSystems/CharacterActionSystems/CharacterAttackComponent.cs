using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterAttackComponent : BaseGameEntityComponent<BaseCharacterEntity>, ICharacterAttackComponent
{
    protected Weapon weapon;
    protected AttackState attackState;

    private float timeCounter;

    public override void EntityAwake()
    {
        base.EntityAwake();

        weapon = Entity.characterData.currentWeapon;
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

    public void Attack(DamageableEntity target)
    {
        MonsterCharacterEntity monster = GetNearestTarget();
        if(monster != null)
        {
            weapon.Apply(monster, Entity, 10);
            attackState = AttackState.Attacking;
            timeCounter = weapon.cooldown;
        }
    }

    private MonsterCharacterEntity GetNearestTarget()
    {
        List<MonsterCharacterEntity> monsters = GameInstance.instance.monsters;
        if (monsters.Count == 0)
            return null;

        Vector2 nearestDistance = monsters.First<MonsterCharacterEntity>().transform.position;
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
