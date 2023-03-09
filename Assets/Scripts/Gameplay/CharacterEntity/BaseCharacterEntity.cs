using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterEntity : DamageableEntity
{
    [Header("Data")]
    public Character characterData;

    protected CharacterAttackComponent characterAttack;

    protected override void EntityAwake()
    {
        base.EntityAwake();

        characterAttack = GetComponent<CharacterAttackComponent>();
    }

    public override float GetMoveSpeed()
    {
        return characterData.movementSpeed;
    }
}
