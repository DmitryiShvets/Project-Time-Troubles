using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
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
        SceneManager.LoadScene("Scenes/Menu");
    }
}
