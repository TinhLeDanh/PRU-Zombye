using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnTakeItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;

    public void onTakeItem() {
        Array.Resize(ref player.items, player.items.Length + 1);

        player.items[player.items.Length-1] =  LoadGameDataAll.instance.itemOpen;
    }
}
