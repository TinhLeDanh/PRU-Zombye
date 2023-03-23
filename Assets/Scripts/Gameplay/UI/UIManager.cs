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
        Loading();
    }

    public void GameOver()
    {
        gameTitleTxt.gameObject.SetActive(true);
        gameTitleTxt.text = "Game Over!";
        restartBtn.gameObject.SetActive(true);
    }

    public void BackHomeScene()
    {
        SceneManager.LoadSceneAsync("GameplayScene");
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync("GameplayScene");
    }

    public void Loading()
    {
        StartCoroutine(LoadCO());
        StartCoroutine(DelayStartGame());
    }

    IEnumerator LoadCO()
    {
        loadingImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(loadTime);
        loadingImg.gameObject.SetActive(false);
    }

    IEnumerator DelayStartGame()
    {
        yield return new WaitForSeconds(delayStartGame);
        GameInstance.instance.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
