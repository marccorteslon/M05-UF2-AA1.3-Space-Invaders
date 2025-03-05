using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f;

    void Start()
    {

    }

    void Update()
    {
        float velocidadX = Input.GetAxis("Horizontal")*Time.deltaTime;
        Vector3 position = transform.position;
        transform.position = new Vector3(velocidadX + position.x, position.y, position.z);
    }
}
