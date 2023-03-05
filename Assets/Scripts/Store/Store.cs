using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panelDefault;
    public GameObject pannelPopUp;
    void Start()
    {
        pannelPopUp.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickOpenBoxGold()
    {
        Debug.Log("onClickOpenBoxGold");
        panelDefault.SetActive(false);
        pannelPopUp.SetActive(true);

    }

    public void onClickOkay()
    {
        panelDefault.SetActive(true);
        pannelPopUp.SetActive(false);


    }
}
