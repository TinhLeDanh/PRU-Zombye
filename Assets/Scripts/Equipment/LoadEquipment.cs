using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadEquipment : MonoBehaviour
{
    public static LoadEquipment instance;
    
    public Player playerData;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        var l = playerData.items;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
