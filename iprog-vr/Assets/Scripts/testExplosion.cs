using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testExplosion : MonoBehaviour
{
    public ParticleSystem Explosion;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Explosion.Play();
            Debug.Log("Explosion");
        }
    }
}
