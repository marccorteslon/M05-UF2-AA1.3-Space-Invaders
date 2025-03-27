using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float speed = 2f;
    public float moveDownAmount = 0.5f;
    public float boundary = 7f;
    public GameObject projectilePrefab;
    public float shootInterval = 2f;
    private int direction = 1;

    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    void Update()
    {
        // Mover el grupo en la dirección actual
        transform.position += Vector3.right * direction * speed * Time.deltaTime;

        // Verificar si algún enemigo ha tocado los límites
        foreach (Transform enemy in transform)
        {
            if (enemy.position.x >= boundary || enemy.position.x <= -boundary)
            {
                MoveDownAndChangeDirection();
                break;
            }
        }
    }

    void MoveDownAndChangeDirection()
    {
        direction *= -1; // Invertir dirección
        transform.position += Vector3.down * moveDownAmount; // Bajar el grupo
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        if (transform.childCount == 0) return;

        Transform randomEnemy = transform.GetChild(Random.Range(0, transform.childCount));
        Instantiate(projectilePrefab, randomEnemy.position, Quaternion.identity);
    }
}
