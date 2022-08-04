using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement_2 : MonoBehaviour
{
    public float speed;

    public float radiusMax;
    public float radiusMin;
    private float _frequency;
    private float _amplitude;
    private float _rotateX;

    private float offset;
    public int coinflip;

    // Start is called before the first frame update
    void Start()
    {
        _frequency = Random.Range(1, 2);
        _amplitude = Random.Range(radiusMin, radiusMax);
        _rotateX = Random.Range(0,-80);

        offset = Random.Range(0, 10);
        coinflip = Random.Range(0, 100);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Cos(Time.time * speed * _frequency + offset) * _amplitude;
        float y = transform.position.y;

        if (coinflip > 50)
        {
            float z = -Mathf.Sin(Time.time * speed * _frequency + offset) * _amplitude;
            transform.position = new Vector3(x, y, z);
            transform.forward += transform.position;
        }
        else if(coinflip <= 50)
        {
            float z = Mathf.Sin(Time.time * speed * _frequency + offset) * _amplitude;
            transform.position = new Vector3(x, y, z);
            transform.forward -= transform.position;
        }

        transform.Rotate(_rotateX, 0, 90);
    }
}
