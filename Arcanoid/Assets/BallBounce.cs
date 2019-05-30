using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public Rigidbody2D rb;
    public float power;
    public bool isInPlay;
    public Transform paddle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInPlay)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButtonDown("Jump") && !isInPlay)
        {
            isInPlay = true;
            rb.AddForce(Vector2.up * power);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))
        {
            Debug.Log("ball has hitted a bottom");

            rb.velocity = Vector2.zero;
            isInPlay = false;
        }
    }
}
