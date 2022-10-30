using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneLoader : MonoBehaviour
{    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadStartScene();
        }
    }

    public void SongSelection()
    {
        //int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex; //No longer needed in this case
        SceneManager.LoadScene(2);
    }

    public void ControlsMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void BadApple()
    {
        SceneManager.LoadScene(3);
    }

    public void CruelAngelsThesis()
    {
        SceneManager.LoadScene(4);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        //FindObjectOfType<GameSession>().ResetGame();      This was previously used in the previous block breaker code. no longer needed
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
