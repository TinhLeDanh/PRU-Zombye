using System.Collections;
using System.Collections.Generic;
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
        weapon.Apply(target, Entity, 10);
        attackState = AttackState.Attacking;
        timeCounter = weapon.cooldown;
    }

    public void CancelAttack()
    {
        throw new System.NotImplementedException();
    }

    public void ClearAttackStates()
    {
        throw new System.NotImplementedException();
    }
}
