using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadANewLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
    
    public void ResetGame()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            LoadANewLevel(buildIndex: 1);
        }
        else
        {
           LoadANewLevel(buildIndex: 0);  
        }
    }
    
    public void NextLevel()
    {
        LoadANewLevel(buildIndex: 1);
    }

    public void ReturnToMenu()
    {
        LoadANewLevel(buildIndex: 0);
    }
}
