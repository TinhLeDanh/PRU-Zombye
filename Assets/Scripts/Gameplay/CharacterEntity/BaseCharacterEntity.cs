using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        return characterData.GetSpeed();
    }

    public void FaceTarget(BaseGameEntity target)
    {
        if (faceDirection == 1 && target.transform.position.x < transform.position.x)
        {
            faceDirection = -1;
            ModelController.transform.localScale *= new Vector2(-1f, 1f);
        }
        else if (faceDirection == -1 && target.transform.position.x > transform.position.x)
        {
            faceDirection = 1;
            ModelController.transform.localScale *= new Vector2(1f, 1f);
        }
    }

    public void FaceRight()
    {
        faceDirection = 1;
        if (ModelController.transform.localScale.x > 0)
            ModelController.transform.localScale *= new Vector2(1f, 1f);
        else
            ModelController.transform.localScale *= new Vector2(-1f, 1f);
    }

    public void FaceLeft()
    {
        faceDirection = -1;
        if (ModelController.transform.localScale.x < 0)
            ModelController.transform.localScale *= new Vector2(1f, 1f);
        else
            ModelController.transform.localScale *= new Vector2(-1f, 1f);
    }

    public override void OnDead()
    {
        base.OnDead();

        rb.bodyType = RigidbodyType2D.Kinematic;
        boxCollider.enabled = false;
    }
}
