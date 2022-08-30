using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ControlType { Normal, WorldTilt }

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public ControlType controlType;
    public GameType gameType;

    private void Awake()
    {  
        if (instance == null)
        {
           instance = this;
           DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    //sets the game type from our selections
    public void SetGameType(GameType _gameType)
    {
        gameType = _gameType;

    }

    //to toggle speedrun on or off
    public void ToggleSpeedRun(bool _SpeedRun)
    {
        if (_SpeedRun)
            SetGameType(GameType.SpeedRun);
        else
            SetGameType(GameType.Normal);
    }

    // Toggles our control type between world tiltand normal
    public void ToggleWorldTilt(bool _tilt)
    {
        if (_tilt)
            controlType = ControlType.WorldTilt;
        else
            controlType = ControlType.Normal;
    }
   
    

}
