using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [Header("Движение и прыжок")]
    public float moveSpeed = 6f;
    public float jumpForce = 8.5f;
    private Rigidbody2D rb;
    private bool isGrounded = false;
    private bool facingRight = true;

    [Header("Здоровье и UI")]
    public int maxHealth = 3;
    private int currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y);

        if (move > 0 && !facingRight) Flip();
        else if (move < 0 && facingRight) Flip();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.contacts[0].normal.y > 0.5f)
            {
                isGrounded = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Enemy"))
        {
            isGrounded = false;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI();

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + currentHealth;
        }
    }
}
