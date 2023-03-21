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
        if (faceDirection == 1 && target.transform.position.x < transform.position.x)
        {
            faceDirection = -1;
            transform.localScale = new Vector2(-1f, 1f);
        }
        else if (faceDirection == -1 && target.transform.position.x > transform.position.x)
        {
            faceDirection = 1;
            transform.localScale = new Vector2(1f, 1f);

        }
    }

    public override void OnDead()
    {
        base.OnDead();
    }
}
