using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenBoxViolet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemOpening;
    public Player player;
    public Button btnOpenViolet;
    public TMP_Text text;
    public TMP_Text nameItem;
    public void onClickOpenBoxViolet()
    {
        Debug.Log("onClickOpenVioletGold");
        LoadGameDataAll.instance.itemOpen = RandomItemRatio.instance.RandomItem(1);
        itemOpening.GetComponent<Image>().sprite = LoadGameDataAll.instance.itemOpen.icon;
        nameItem.text = LoadGameDataAll.instance.itemOpen.name;
        player.RemoveGold(500);
        Refresh();
    }

    public void Refresh()
    {
        text.text = "x" + player.gold.ToString();

        if (player.gold >= 500)
        {
            btnOpenViolet.interactable = true;
        }
        else
        {
            btnOpenViolet.interactable = false;
        }
    }
}
