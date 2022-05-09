using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    //  Scenes/Temple
    public string lvlName;
    private bool canUse;

    // Start is called before the first frame update
    void Start()
    {
        canUse = false;
        StartCoroutine(Delay());
    }

    IEnumerator Delay() 
    {
        yield return new WaitForSeconds(1);
        canUse = true;
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (canUse) Game.LoadSceneSave(lvlName);
        //  SceneManager.LoadScene(lvlName);
    }
}