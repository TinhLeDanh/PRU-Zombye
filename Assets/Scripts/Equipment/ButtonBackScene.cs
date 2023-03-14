using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBackScene : MonoBehaviour
{
    public void OnBackScene()
    {
        SceneManager.LoadSceneAsync("Equipment");
    }
}
