using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveGame : MonoBehaviour

{
    public Player playerData;
    public void OnSaveGame()
    {
        Debug.Log("Save Game");
        playerData.OnSaveGame();
    }
}
