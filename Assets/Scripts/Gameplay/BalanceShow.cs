using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BalanceShow : MonoBehaviour
{
    public Player player;
    public TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        text.text ="x " +player.gold;
    }
}
