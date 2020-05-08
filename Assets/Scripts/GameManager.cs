using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameData data;
    public Ball ball;
    public Text scoreText;
    public Text highScoreText;
    public int Score { get; private set; }
    public int HighScore { get; private set; }
    

    private void Start()
    {
        if(SaveLoadManager.LoadScores() != null)
        {
            data = SaveLoadManager.LoadScores();
            Debug.Log("Score:" + data.Score + " HScore:" + data.HighScore);
            Score = data.Score;
            scoreText.text = Score.ToString();

            HighScore = data.HighScore;
            highScoreText.text = HighScore.ToString();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveLoadManager.SavePlayerPosition(FindObjectOfType<Player>().transform.position.x,
                FindObjectOfType<Player>().transform.position.y);
            SaveLoadManager.SaveScores(Score, HighScore);
            SaveLoadManager.SaveBallState(ball);
            SceneManager.LoadScene(0);
        }

    }

   

    public void ResetPlayerAndReload()
    {
        SaveLoadManager.SavePlayerPosition(0,-4f);
        SaveLoadManager.SaveScores(Score, HighScore);
        SaveLoadManager.SaveBallState(ball);
        SceneManager.LoadScene(1);
    }

   

    public void MakeScore()
    {
        Debug.Log("Topa çarptı");
        Score++;
        scoreText.text = Score.ToString();

        if (Score > HighScore)
        {
            HighScore = Score;
            highScoreText.text = HighScore.ToString();

            SaveLoadManager.SaveScores(Score,HighScore);

        }

        if (Score % 5 == 0)
        {
            FindObjectOfType<Player>().transform.position += new Vector3(0, 1, 0);
            SaveLoadManager.SavePlayerPosition(FindObjectOfType<Player>().transform.position.x,
                FindObjectOfType<Player>().transform.position.y);
        }

    }

}
