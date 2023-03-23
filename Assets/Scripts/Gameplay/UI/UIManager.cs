using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TMP_Text gameTitleTxt;

    [Header("Loading")]
    public float loadTime;
    public float delayStartGame;
    public Image loadingImg;

    [Header("Button")]
    public Button restartBtn;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        loadingImg.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        gameTitleTxt.gameObject.SetActive(true);
        gameTitleTxt.text = "Game Over!";
        restartBtn.gameObject.SetActive(true);
    }

    public void BackHomeScene()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync("GameplayScene");
    }

    public void MapLoaded()
    {
        loadingImg.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
