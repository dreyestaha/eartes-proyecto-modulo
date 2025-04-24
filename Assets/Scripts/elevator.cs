using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class elevator : MonoBehaviour
{
    [SerializeField] private float velocidad = 1f;
    [SerializeField] private float amplitud = 15f;
    private Vector3 initPosition;
    void Start()
    {
        initPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //onCollisionEnter para activar el elevador, luego pasar la función al update
        if (collision.gameObject.CompareTag("Player"))
        {
            float desplazamientoY = Mathf.Sin(Time.time * velocidad) * amplitud;
            transform.position = new Vector3(initPosition.x, initPosition.y + desplazamientoY, initPosition.z);
        }
    }
}
