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

            if (data.items != null)
            {
                var rand = (float)Random.Range(1, 101) / 100;
                if (data.dropItemRate >= rand)
                {
                    //drop item
                    var randItem = Random.Range(0, data.items.Length);
                    var lootableItem = Instantiate(lootItemPrefab,
                        transform.position + new Vector3(-0.25f, -0.25f, 0), Quaternion.identity);
                    lootableItem.SetupData(0, 0, data.items[randItem]);
                }
            }

            if (data.gold > 0)
            {
                // drop gold
                var randRateGold = (float)Random.Range(1, 101) / 100;
                if (randRateGold <= data.dropGoldRate)
                {
                    LootableItem lootableGold = Instantiate(lootItemPrefab,
                        transform.position + new Vector3(0.25f, 0.25f, 0), Quaternion.identity);
                    lootableGold.SetupData(0, data.gold, null);
                }
            }

            if (data.exp > 0)
            {
                // // drop exp
                var lootableExp = Instantiate(lootItemPrefab,
                    transform.position + new Vector3(0.25f, -0.25f, 0), Quaternion.identity);
                lootableExp.SetupData(data.exp, 0, null);
            }
        }
    }
}