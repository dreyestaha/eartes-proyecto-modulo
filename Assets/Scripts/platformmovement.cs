using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformmovement : MonoBehaviour
{
    [SerializeField] private float velocidadX = 0f;
    [SerializeField] private float amplitudX = 0;
    [SerializeField] private float velocidadY = 0f;
    [SerializeField] private float amplitudY = 0f;
    [SerializeField] private float velocidadZ = 0f;
    [SerializeField] private float amplitudZ = 0f;

    private Vector3 position;
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float desplazamientoX = Mathf.Sin(Time.time * velocidadX) * amplitudX;
        float desplazamientoY = Mathf.Sin(Time.time * velocidadY) * amplitudY;
        float desplazamientoZ = Mathf.Sin(Time.time * velocidadZ) * amplitudZ;
        transform.position = new Vector3(position.x + desplazamientoX, position.y + desplazamientoY, position.z + desplazamientoZ);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(null);
        }
    }
}
