using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public Transform firePoint; // Punto de salida del proyectil

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detectar clic izquierdo
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.up * projectileSpeed; // Movimiento hacia arriba
                rb.gravityScale = 0; // Desactiva la gravedad (por si acaso)
            }
        }
    }

}
