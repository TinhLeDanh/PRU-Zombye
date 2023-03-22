using Unity.VisualScripting;
using UnityEngine;

public class LootableItem : MonoBehaviour
{
    public LayerMask playerLayer;
    public Player player;
    public int exp;
    public int gold;
    public Item item;

    public void SetupData(int exp, int gold, Item item)
    {
        this.exp = exp;
        this.gold = gold;
        this.item = item;
        this.item.GetComponent<SpriteRenderer>().sprite = item.icon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayermaskExtensions.Contains(playerLayer, collision.gameObject))
        {
            LevelSystem.Instance.GainExperienceFlatRate(exp);
            player.AddGold(gold);
            Destroy(this.gameObject);
        }
    }
}