using System.Collections.Generic;
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

    public override void OnDead()
    {
        base.OnDead();

        WaveManager.instance.OnKilledEnemy();
        Monster data;
        if (characterData is Monster monsterData)
        {
            data = monsterData;
            
            if (data.items.Length > 0)
            {
                //drop item
                var lootableItem = Instantiate(lootItemPrefab, transform.position, Quaternion.identity);
                lootableItem.SetupData(0, 0, data.items[0]);
                Debug.Log("item: " + data.items[0].itemName);
            }

            if (data.gold > 0)
            {
                // drop gold
                var lootableGold = Instantiate(lootItemPrefab, transform.position, Quaternion.identity);
                lootableGold.SetupData(0, data.gold, null);
                Debug.Log("gold: " + data.gold);
            }

            if (data.exp > 0)
            {
                // drop exp
                var lootableExp = Instantiate(lootItemPrefab, transform.position, Quaternion.identity);
                lootableExp.SetupData(data.exp, 0, null);
                Debug.Log("exp: " + data.exp);
            }
        }
    }
}