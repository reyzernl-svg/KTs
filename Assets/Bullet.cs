using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;
    public float lifeTime = 3f; // Самоуничтожение, если улетела в пустоту

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Если попали во врага — наносим ему урон
        StaticEnemy enemy = collision.gameObject.GetComponent<StaticEnemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        // Уничтожаем пулю при столкновении с любым объектом
        Destroy(gameObject);
    }
}
