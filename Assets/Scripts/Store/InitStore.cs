using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InitStore : MonoBehaviour
{
    public Button btnOpenGold;
    public Button btnOpenViolet;
    public TMP_Text text;
    public Player player;
    void Start()
    {
        
        text.text = "x" + player.gold.ToString();

        if (player.gold >= 100)
        {
            btnOpenGold.interactable = true;
        }
        else
        {
            btnOpenGold.interactable = false;
        }


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
