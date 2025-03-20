using UnityEngine;
using System.Collections;

public class ZigZagStepMovement : MonoBehaviour
{
    public int stepsPerRow = 5; // Cantidad de pasos en cada dirección
    public float stepSize = 0.5f; // Tamaño de cada paso
    public float stepDelay = 1f; // Tiempo entre cada paso

    private int currentStep = 0;
    private int direction = 1; // 1 para derecha, -1 para izquierda

    void Start()
    {
        StartCoroutine(MoveInSteps());
    }

    IEnumerator MoveInSteps()
    {
        while (true) // Bucle infinito
        {
            // Calcula la nueva posición
            Vector2 targetPosition = (Vector2)transform.position + new Vector2(stepSize * direction, 0);

            if (currentStep < stepsPerRow)
            {
                // Mover a la derecha o izquierda
                transform.position = targetPosition;
                currentStep++;
            }
            else
            {
                // Cambiar dirección y bajar
                transform.position += new Vector3(0, -stepSize, 0);
                currentStep = 0;
                direction *= -1;
            }

            yield return new WaitForSeconds(stepDelay); // Espera antes del siguiente paso
        }
    }
}
