using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public bool isInPlay;
    public Transform paddle;
    public Transform explosion;
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GM.gameOver)
        {
            return;
        }

        if (!isInPlay)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && !isInPlay)
        {
            isInPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))
        {
            rb.velocity = Vector2.zero;
            isInPlay = false;
            GM.UpdateLives(-1);
         }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Block"))
        {
            var brickScript = collision.gameObject.GetComponent<BlockScript>();

            if (brickScript.blockHP == 3)
            {
                brickScript.BreakBlock();
                GM.UpdateScores(brickScript.points);
            }
            else if (brickScript.blockHP == 2)
            {
                brickScript.SecondBreakBlock();
                GM.UpdateScores(brickScript.points);
            }
            else
            {
                var boom = Instantiate(explosion, collision.transform.position, collision.transform.rotation);
                Destroy(collision.gameObject);

                GM.UpdateScores(brickScript.points + 1);
                GM.UpdateNumberOfBricks();

                Destroy(boom.gameObject, 2.5f);
            }           
        }
    }
}
