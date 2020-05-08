using UnityEngine;

[System.Serializable]
public class GameData 
{
    public int Score;
    public int HighScore;
    public float PlayerPositionX;
    public float PlayerPositionY;
    public float BallPositionX;
    public float BallPositionY;
    public float BallVelocityX;
    

    public GameData(float xPosition,float yPosition)
    {
        PlayerPositionX = xPosition;
        PlayerPositionY = yPosition;
    }
    public GameData(int score,int highScore)
    {
        Score = score;
        HighScore = highScore;
    }
    public GameData(Ball ball)
    {
        if(ball != null)
        {
        BallPositionX = ball.transform.position.x;
        BallPositionY = ball.transform.position.y;
        BallVelocityX = ball.GetComponent<Rigidbody2D>().velocity.x;
        }
        
    }
}
