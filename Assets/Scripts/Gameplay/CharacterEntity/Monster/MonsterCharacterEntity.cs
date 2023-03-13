using UnityEngine;

public class MonsterCharacterEntity : BaseCharacterEntity
{
    public override void InitialRequiredComponents()
    {
        base.InitialRequiredComponents();
    }

    protected override void EntityStart()
    {
        base.EntityStart();

        target = GameInstance.instance.player;
    }
    
    protected override void EntityUpdate()
    {
        base.EntityUpdate();

        if (characterAttack.CanAttack())
        {
            characterAttack.Attack();
        }
    }
}
