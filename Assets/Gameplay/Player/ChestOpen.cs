using System;
using System.Collections;
using System.Collections.Generic;
using Core.GameData.Storage;
using Gameplay;
using UnityEngine;
using TMPro;
using UnityEditor;
using ScriptableObjects;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;

public class ChestOpen : MonoBehaviour
{
    private bool canUse = false;
    public Sprite newSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "PlayCollider")
        {
            canUse = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "PlayerCollider")
        {
            canUse = false;
        }
    }

    void Update()
    {
        if (canUse && Input.GetKey(KeyCode.E))
        {
            Debug.Log("Сундук открыт");
            GetComponent<Image>().sprite = newSprite;
        }
    }
}