using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum WallType { Normal,Punishing}

public class SceneControllor : MonoBehaviour
{
    public static SceneControllor instance;
    public WallType wallType;

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

    // this is to have a toggle button for on or off, punishing walls
    public void ToggleWallType(bool _punishing)
    {
        if (_punishing)
            wallType = WallType.Punishing;
        else
            wallType = WallType.Normal;
    }
    
    
    // Start is called before the first frame update
    public void ChangeScene(string RollBall)
    {
        SceneManager.LoadScene(RollBall);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Loads out Title Screen, must be called Title exactly for this code to work
    public void ToTitleScene()
    {
        SceneManager.LoadScene("Title");
        GameController.instance.controlType = ControlType.Normal;
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

   
}
