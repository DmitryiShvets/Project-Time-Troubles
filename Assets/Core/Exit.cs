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
    public string requirementItem;
    private bool canUse;

    GameModel model = Schedule.GetModel<GameModel>();

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
        if (canUse)
        {
            if (requirementItem != "")
            {
                if (model.HasItem(requirementItem))
                {
                    Game.LoadSceneSave(lvlName);
                }
            }
            else
            {
                Game.LoadSceneSave(lvlName);
            }
        }
    }
    //  SceneManager.LoadScene(lvlName);
}