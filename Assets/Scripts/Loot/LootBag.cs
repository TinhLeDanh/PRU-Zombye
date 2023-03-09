using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// attach to game object (enemies) we want to drop loot
public class LootBag : MonoBehaviour
{
    public GameObject droppedItemPrefab;

    public List<Loot> lootList = new List<Loot>();

    private Loot GetDroppedItem()
    {
        var randNumber = Random.Range(1, 101);
        var possibleItems = new List<Loot>();
        foreach (var item in lootList)
        {
            if (randNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }

        if (possibleItems.Count > 0)
        {
            var droppedItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return droppedItem;
        }

        return null;
    }

    private List<Loot> GetDroppedItems()
    {
        var randNumber = Random.Range(1, 101);
        var possibleItems = new List<Loot>();
        foreach (var item in lootList)
        {
            if (randNumber <= item.dropChance)
            {
                possibleItems.Add(item);
            }
        }

        if (possibleItems.Count > 0)
        {
            return possibleItems;
        }

        return null;
    }

    public void InstantiateLoot(Vector3 spawnPosition)
    {
        var droppedItem = GetDroppedItem();
        if (droppedItem != null)
        {
            var lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
            lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;

            var dropForce = 300f;
            var dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
        }
    }
    
    public void InstantiateLootList(Vector3 spawnPosition)
    {
        var droppedItems = GetDroppedItems();
        if (droppedItems != null)
        {
            foreach (var droppedItem in droppedItems)
            {
                var lootGameObject = Instantiate(droppedItemPrefab, spawnPosition, Quaternion.identity);
                lootGameObject.GetComponent<SpriteRenderer>().sprite = droppedItem.lootSprite;

                var dropForce = 300f;
                var dropDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                lootGameObject.GetComponent<Rigidbody2D>().AddForce(dropDirection * dropForce, ForceMode2D.Impulse);
            }
        }
    }
}