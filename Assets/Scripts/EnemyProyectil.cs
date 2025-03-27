using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 5f; // Mantén el valor positivo

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime; // Baja correctamente
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Shield"))
        {
            Destroy(gameObject);
        }
    }
}
