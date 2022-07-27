using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControllor : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene(string RollBall)
    {
        SceneManager.LoadScene(RollBall);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
   
    public void ToTitleScene()
    {
        SceneManager.LoadScene("Title");
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
