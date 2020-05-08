
using UnityEngine;


public class Ball : MonoBehaviour
{
    private GameData gameData;
    public float moveSpeed = 10;
    public Rigidbody2D rb;
    float time = 2.0f;

    private void Start()
    {
        if (SaveLoadManager.LoadBallState() != null)
        {
            gameData = SaveLoadManager.LoadBallState();
            Debug.Log("Velo:"+gameData.BallVelocityX);
            if(gameData.BallVelocityX == 0)
            {
                Invoke("StartMoving", 2);
            }
            else
            {
                transform.position = new Vector2(gameData.BallPositionX,gameData.BallPositionY);
                rb.velocity = new Vector2(gameData.BallVelocityX, 0);
            }
            
        }
        else
        Invoke("StartMoving", 2);
    }

    private void Update()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            return;
        }
        else
        {
            if (Mathf.Abs(rb.velocity.x) < 10)
            {
                if (rb.velocity.x < 0)
                    rb.velocity = new Vector2(-15, 0);
                else
                    rb.velocity = new Vector2(15, 0);
            }
            if (Mathf.Abs(rb.velocity.x) > 20)
            {
                if (rb.velocity.x < 0)
                    rb.velocity = new Vector2(-15, 0);
                else
                    rb.velocity = new Vector2(15, 0);
            }
        }
    }

    void StartMoving()
    {
        rb.velocity = new Vector2(1, 0) * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name != "bomb(Clone)")
        GetComponent<AudioSource>().Play();

        if (collision.gameObject.name == "bomb(Clone)")
        {
            FindObjectOfType<GameManager>().GetComponent<GameManager>().MakeScore();
            Destroy(collision.gameObject);
        }
    }

}
