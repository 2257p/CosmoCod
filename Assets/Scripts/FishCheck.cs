using UnityEngine;

public class FishCheck : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isInsideSquare = false;
    float enterTime = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isInsideSquare)
        {
            if (Time.time - enterTime >= 1.5f)
            {
                Debug.Log("test");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Square"))
        {
            isInsideSquare = true;
            enterTime = Time.time;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Square"))
        {
            isInsideSquare = false;
        }
    }

    void FixedUpdate()
    {
        if (rb.position.y <= -2.25f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 9f);
        }
    }
}