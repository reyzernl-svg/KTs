using UnityEngine;

public class StaticEnemy : MonoBehaviour
{
    public int health = 2;
    public int damageToPlayer = 1;
    private bool isDead = false;
    private Rigidbody2D rb;
    private Renderer meshRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        meshRenderer = GetComponent<Renderer>();
        rb.bodyType = RigidbodyType2D.Static;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.mass = 1.5f;

        if (meshRenderer != null)
        {
            meshRenderer.material.color = Color.black;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead && collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDamage(damageToPlayer);
            }
        }
    }
}
