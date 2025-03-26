using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public float speed = 2f;
    public float moveDownAmount = 0.5f;
    public float boundary = 7f;
    private int direction = 1;

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
}
