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
            AudioManager.Play(AudioClipName.TeddyShot);
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

            //drop exp
            LootableItem lootableItem = Instantiate(lootItemPrefab, transform.position, Quaternion.identity);
            lootableItem.SetupData(monsterData.exp, 0, data.items[0]);
        }  
    }
}
