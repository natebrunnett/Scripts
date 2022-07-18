using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public static GameScript instance;
    public bool playState, menuState, keyboardPlay, mousePlay;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
        menuState = true;
        playState = false;
        keyboardPlay = false;
        mousePlay = false;
        Debug.Log("GameScipt.Start");
    }
}
