using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnMissile : MonoBehaviour
{
    private float speed = 10;
    private Transform target;
    private int enemyNum;
    private int rng;

    void Start()
    {
        enemyNum = Random.Range(1,3);
        switch (enemyNum)
        {
            case (1):
                target = GameObject.Find("Missile_turret").transform;
                break;
            case (2):
                target = GameObject.Find("Minigun_turret Lvl 2").transform;
                break;
            case (3):
                target = GameObject.Find("Missile_turret Lvl 1").transform;
                break;
            case (4):
                target = GameObject.Find("Missile_turret").transform;
                break;
        }
    }

    void Update()
    {
        Vector3 tgtPos = target.position - transform.position;
        Vector3 turRotation = Vector3.RotateTowards(transform.forward, tgtPos, speed * Time.deltaTime, 0);
        transform.rotation = Quaternion.LookRotation(turRotation);

        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        rng = Random.Range(1, 100);
        Debug.Log(rng);
    }

    public void LockTarget(Transform tgt)
    {
        target = tgt;
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (rng <= 30)
        {
            Debug.Log("hit self");
            Destroy(gameObject);
        }
        else
        {
            if(collision.gameObject.tag != "Enemy")
            {
                Destroy(gameObject);
            }
        }
    }
}
