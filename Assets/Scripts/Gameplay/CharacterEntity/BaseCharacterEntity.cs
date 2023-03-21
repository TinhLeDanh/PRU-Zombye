using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterEntity : DamageableEntity
{
    public float faceDirection = 1;

    public LootableItem lootItemPrefab;
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

    public void FaceTarget(BaseGameEntity target)
    {
        
    }

    public override void OnDead()
    {
        base.OnDead();
    }
}
