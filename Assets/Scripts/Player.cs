using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Range(100f, 1000f)]
    public float bombSpeed = 200f;
    public float playerMoveSpeed = 50f;
    public GameObject bombPrefab;
    private float moveAxis;
    GameData data;


    private void Start()
    {
        if(SaveLoadManager.LoadPlayerPosition() != null)
        {
        data = SaveLoadManager.LoadPlayerPosition();
        transform.position = new Vector2(data.PlayerPositionX, data.PlayerPositionY);
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            FindObjectOfType<GameManager>().GetComponent<GameManager>().ResetPlayerAndReload();
        }
    }

    private void Move()
    {
        moveAxis = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveAxis * playerMoveSpeed, 0);
    }

    private void Shoot()
    {
        var bomb = Instantiate(bombPrefab, transform.position + new Vector3(0,1,0), Quaternion.identity);
        bomb.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * bombSpeed);
        Destroy(bomb, 2);
    }
}
