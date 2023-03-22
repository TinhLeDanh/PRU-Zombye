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

            var randNumber = Random.Range(1, 101);
            var possibleItems = new List<Item>();
            var droppedItem = new Item();
            foreach (var item in data.items)
            {
                if (randNumber <= item.dropChance)
                {
                    possibleItems.Add(item);
                }
            }

            if (possibleItems.Count > 0)
            {
                droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
                //drop item
                var lootableItem = Instantiate(lootItemPrefab, transform.position, Quaternion.identity);
                lootableItem.SetupData(0, 0, droppedItem);
                Debug.Log("item: "+droppedItem.itemName);
            }

            if (data.gold > 0)
            {
                // drop gold
                var lootableGold = Instantiate(lootItemPrefab, transform.position, Quaternion.identity);
                lootableGold.SetupData(0, data.gold, null);
                Debug.Log("gold: "+data.gold);
            }

            if (data.exp > 0)
            {
                // drop exp
                var lootableExp = Instantiate(lootItemPrefab, transform.position, Quaternion.identity);
                lootableExp.SetupData(data.exp, 0, null);
                Debug.Log("exp: "+data.exp);
            }
        }
    }
}