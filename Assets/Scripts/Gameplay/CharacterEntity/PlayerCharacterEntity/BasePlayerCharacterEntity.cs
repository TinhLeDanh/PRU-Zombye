using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerCharacterEntity : BaseCharacterEntity
{
    public float enemySpawnRadius = 10f;

    protected override void EntityUpdate()
    {
        base.EntityUpdate();

        //If player not move, start attack
        if (Movement.MovementState == MovementState.None && characterAttack.CanAttack())
        {
            if (target is DamageableEntity damageableTarget)
                characterAttack.Attack(damageableTarget);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemySpawnRadius);
    }
}
