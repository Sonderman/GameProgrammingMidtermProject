
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    public void ResetScore()
    {
        SaveLoadManager.SaveScores(0,0);
        SaveLoadManager.SavePlayerPosition(0,-4f);
        SaveLoadManager.SaveBallState(null);
    }

    public void NewGame()
    {
        GameData data;
        SaveLoadManager.SavePlayerPosition(0,-4f);
        if (SaveLoadManager.LoadScores() != null)
        {
          data = SaveLoadManager.LoadScores();
          SaveLoadManager.SaveScores(0,data.HighScore);
        }
        SaveLoadManager.SaveBallState(null);
        SceneManager.LoadScene(1);
    }

    public void LoadLastGame()
    { 
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
