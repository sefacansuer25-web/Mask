using UnityEngine;

public class LVL_3_KarakterKontrol : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;

    bool isGrounded;
    float horizontal;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // INPUT SADECE BURADA
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        // HAREKET F�Z�KLE
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // eski z�plamay� s�f�rla
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Graund"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Graund"))
        {
            isGrounded = false;
        }
    }
}
