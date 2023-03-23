using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemRatio : MonoBehaviour
{
    public static RandomItemRatio instance;

    public Player playerDataAll;

    private void Awake()
    {
        instance = this;
    }

    public Item RandomItem(int salt)
    {
        // salt 0  rương vàng  -  80% xám 20% vàng - 100 coin
        // salt 1 rương kim cương -  20% xám 30% vàng 50% tím - 500 coin

        int typeItem = Random.Range(0, 5); //0 - 4
        int rankItem = 0; //0 - 2
        int levelItem = 1; //default
        int pendingRandom = Random.Range(0, 9);

        switch (salt)
        {
            case 0:
                if (pendingRandom >= 8)
                {
                    rankItem = 1;
                }
                else
                {
                    rankItem = 0;
                }
                break;
            case 1:
                if (pendingRandom <= 1)
                {
                    rankItem = 0;
                }
                else if (pendingRandom <= 4)
                {
                    rankItem = 1;
                }
                else
                {
                    rankItem = 2;
                }
                break;
        }

        int indexItem = typeItem * 3 * 5 + rankItem * 5 + levelItem -1;
        var listItem = playerDataAll.items;
        return listItem[indexItem];
    }
}
