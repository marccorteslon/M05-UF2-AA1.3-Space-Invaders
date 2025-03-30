using UnityEngine;

public class ShieldDeath : MonoBehaviour
{
    public int vidas = 3;
    public float reductionFactor = 0.8f;

    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet") || collision.CompareTag("PlayerBullet"))
        {
            vidas--;
            ReduceSize();

            if (vidas <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void ReduceSize()
    {
        transform.localScale = new Vector3(transform.localScale.x * reductionFactor, transform.localScale.y, transform.localScale.z);
    }
}
