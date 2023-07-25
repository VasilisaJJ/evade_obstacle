using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float constantRiseSpeed = 2f;

    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool hasControl = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!hasControl) return;
        isJumping = false;
        if (Input.GetKey(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (isJumping && hasControl)
        {
            rb.AddForce(Vector2.up * constantRiseSpeed, ForceMode2D.Impulse);
        }
    }

    public void EndGame()
    {
        hasControl = false;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
    }

    public void StartGame()
    {
        hasControl = true;
        rb.gravityScale = 0.7f;
    }
}