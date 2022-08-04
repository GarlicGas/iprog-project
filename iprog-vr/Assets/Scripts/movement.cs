using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float _rotateX;

    public float velocidadMax;

    public float xMax;
    public float zMax;
    public float xMin;
    public float zMin;

    private float x;
    private float z;
    private float tiempo;
    private float angulo;

    // Use this for initialization
    void Start()
    {
        x = Random.Range(-velocidadMax, velocidadMax);
        z = Random.Range(-velocidadMax, velocidadMax);
        angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
        transform.localRotation = Quaternion.Euler(180, angulo, -90);
    }

    // Update is called once per frame
    void Update()
    {

        

        tiempo += Time.deltaTime;

        if (transform.localPosition.x > xMax)
        {
            _rotateX = Random.Range(180, 260);
            x = Random.Range(-velocidadMax, 0.0f);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(_rotateX, angulo, -90);
            tiempo = 0.0f;
        }
        if (transform.localPosition.x < xMin)
        {
            _rotateX = Random.Range(180, 260);
            x = Random.Range(0.0f, velocidadMax);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(_rotateX, angulo, -90);
            tiempo = 0.0f;
        }
        if (transform.localPosition.z > zMax)
        {
            _rotateX = Random.Range(180, 260);
            z = Random.Range(-velocidadMax, 0.0f);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(_rotateX, angulo, -90);
            tiempo = 0.0f;
        }
        if (transform.localPosition.z < zMin)
        {
            _rotateX = Random.Range(180, 260);
            z = Random.Range(0.0f, velocidadMax);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(_rotateX, angulo, -90);
            tiempo = 0.0f;
        }


        if (tiempo > 1.0f)
        {
            _rotateX = Random.Range(180, 260);
            x = Random.Range(-velocidadMax, velocidadMax);
            z = Random.Range(-velocidadMax, velocidadMax);
            angulo = Mathf.Atan2(x, z) * (180 / 3.141592f) + 90;
            transform.localRotation = Quaternion.Euler(_rotateX, angulo, -90);
            tiempo = 0.0f;
        }

        transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);

    }
}
