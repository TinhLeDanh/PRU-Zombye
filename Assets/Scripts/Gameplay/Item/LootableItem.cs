using UnityEngine;

public class LootableItem : MonoBehaviour
{
    public LayerMask playerLayer;
    public Player player;
    public SpriteRenderer spriteRenderer;
    public int exp;
    public int gold;
    public Item item;

    [Header("Icon")] public Sprite expSprite;
    public Sprite goldSprite;

    private void Awake()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void SetupData(int exp, int gold, Item item)
    {
        this.exp = exp;
        this.gold = gold;
        if (item != null)
        {
            this.item = item;
            spriteRenderer.sprite = item.icon;
        }

        if (exp > 0)
        {
            spriteRenderer.sprite = expSprite;
        }

        if (gold > 0)
        {
            spriteRenderer.sprite = goldSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayermaskExtensions.Contains(playerLayer, collision.gameObject))
        {
            LevelSystem.Instance.GainExperienceFlatRate(exp);
            player.AddGold(gold);
            player.AddItem(item);
            Destroy(this.gameObject);
        }
    }
}