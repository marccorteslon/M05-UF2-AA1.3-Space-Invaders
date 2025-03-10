using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 20f;
    private bool puedeMoverIzquierda = true;
    private bool puedeMoverDerecha = true;

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");

        if ((inputX < 0 && !puedeMoverIzquierda) || (inputX > 0 && !puedeMoverDerecha))
        {
            return; // No permite moverse en la dirección bloqueada
        }

        float velocidadX = inputX * velocidad * Time.deltaTime;
        transform.position += new Vector3(velocidadX, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LimitLeft"))
        {
            Debug.Log("Colisión con el límite izquierdo");
            puedeMoverIzquierda = false;
        }
        else if (collision.CompareTag("LimitRight"))
        {
            Debug.Log("Colisión con el límite derecho");
            puedeMoverDerecha = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("LimitLeft"))
        {
            puedeMoverIzquierda = true;
        }
        else if (collision.CompareTag("LimitRight"))
        {
            puedeMoverDerecha = true;
        }
    }
}
