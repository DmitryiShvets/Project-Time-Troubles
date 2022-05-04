using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{   //  Scenes/Temple
    public string lvlName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void OnCollisionStay2D(Collision2D other)
    {
        
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Game.LoadScene(lvlName);
        //  SceneManager.LoadScene(lvlName);
    }
}
