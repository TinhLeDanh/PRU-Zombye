using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToEquipment()
    {
        SceneManager.LoadSceneAsync("Equipment");
    }
    public void ToGameplayScene()
    {
        SceneManager.LoadSceneAsync("GameplayScene");
    }
    public void ToStore()
    {
        SceneManager.LoadSceneAsync("Store");
    }
}
