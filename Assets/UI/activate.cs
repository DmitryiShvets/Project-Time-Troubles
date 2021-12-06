using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

public class activate : MonoBehaviour
{
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        var uicontroller = gameObject.GetComponent<UIController>();
        uicontroller.ActivateMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
