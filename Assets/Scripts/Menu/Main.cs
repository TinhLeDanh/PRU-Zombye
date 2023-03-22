using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Player playerData;
    public Player playerDataDefault;
    public GameObject btnResume;

    private void Start()
    {
        if (playerData.Name.Equals(playerDataDefault.Name) &&
        playerData.gold == playerDataDefault.gold &&
        playerData.health == playerDataDefault.health &&
        playerData.movementSpeed ==playerDataDefault.movementSpeed &&
        playerData.currentWeapon.Equals(playerDataDefault.currentWeapon)) {
            Debug.Log("Not Resume");
            btnResume.SetActive(false);
        }
    }

    public void ToNewGame() {
        Debug.Log("New Game");
        playerData.Name = playerDataDefault.Name;
        playerData.gold = playerDataDefault.gold;
        playerData.health = playerDataDefault.health;
        playerData.movementSpeed = playerDataDefault.movementSpeed;
        playerData.currentWeapon = playerDataDefault.currentWeapon;
        playerData.items = playerDataDefault.items;
        SceneManager.LoadSceneAsync("GameplayScene");
    }
}
