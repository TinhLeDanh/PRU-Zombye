using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCharacterEntity : BaseCharacterEntity
{
    public override void InitialRequiredComponents()
    {
        base.InitialRequiredComponents();

        target = GameInstance.instance.player;
    }
}
