using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnMissile : MonoBehaviour
{
    private float speed = 20;
    public Transform target;
    private int enemyNum;
    private bool fired;
    private int KillRng;
    public ParticleSystem explosion;
    private float lifetime = 5f;

    void Start()
    {
        fired = false;
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

        if(fired == false)
        {
            SelfDestruct();
            fired = true;
        }

        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
        }
        else if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void LockTarget(Transform tgt)
    {
        target = tgt;
    }

    public void SelfDestruct()
    {
        var Rng = Random.Range(0, 100);
        Debug.Log(Rng);
        if (Rng <= 30)
        {
            explosion.Play();
            Destroy(gameObject);
        }
    }

    //does not work
    public void killSelf()
    {
        KillRng = Random.Range(0, 100);
        Debug.Log(KillRng);
        if (KillRng <= 50)
        {
            target = GameObject.FindGameObjectWithTag("Enemy").transform;

            Vector3 tgtPos2 = target.position - transform.position;
            Vector3 turRotation2 = Vector3.RotateTowards(transform.forward, tgtPos2, speed * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(turRotation2);

            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
            if (collision.gameObject.tag != "Enemy")
            {
                explosion.Play();
                Destroy(gameObject);
            }
    }
}
