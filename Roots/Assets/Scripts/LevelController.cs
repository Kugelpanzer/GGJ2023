using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;

    private void Awake()
    {
        if( instance== null)
        {
            instance= this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public int SceneIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);

    }
    public void GoToScene(int i)
    {
        SceneManager.LoadScene(i);

    }
    public void ResetLevel()
    {

    }

}
