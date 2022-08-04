using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTest : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void receiveDmg(float damage)
    {
        Debug.Log(health);
        health -= damage;
    }
}
