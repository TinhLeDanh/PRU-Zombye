using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenBoxGold : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemOpening;
    public Player player;
    public Button btnOpenGold;
    public TMP_Text text;
    public TMP_Text nameItem;
    public void onClickOpenBoxGold()
    {
        Debug.Log("onClickOpenBoxGold");
        LoadGameDataAll.instance.itemOpen = RandomItemRatio.instance.RandomItem(0);
        itemOpening.GetComponent<Image>().sprite = LoadGameDataAll.instance.itemOpen.icon;
        nameItem.text = LoadGameDataAll.instance.itemOpen.name;
        player.RemoveGold(100);
        Refresh();
    }

    public void Refresh() {
        text.text = "x" + player.gold.ToString();

        if (player.gold >= 100)
        {
            btnOpenGold.interactable = true;
        }
        else
        {
            btnOpenGold.interactable = false;
        }
    }
}
