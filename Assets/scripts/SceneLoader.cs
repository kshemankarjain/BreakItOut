using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentSceneIndex + 1);
    }
    public void ApplicationQuit()
    {
        Application.Quit();
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start Menu");
        FindObjectOfType<GameStatus>().ResetGame();
    }
    public void LoadLevelScreen()
    {
        SceneManager.LoadScene("ChooseLevel");
    }
    public void loaddinglevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void loaddingleve2()
    {
        SceneManager.LoadScene("Level 2");
    } public void loaddinglevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void loaddinglevel4()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void loaddinglevel5()
    {
        SceneManager.LoadScene("Level 5");
    }


}
