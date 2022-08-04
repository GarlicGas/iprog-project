using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMissile : MonoBehaviour
{
    private Transform target;
    private float speed = 25f;
    private bool rolled;
    private float lifetime = 5f;

    private void Start()
    {
        rolled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 tgtPos = target.position - transform.position;
            Vector3 turRotation = Vector3.RotateTowards(transform.forward, tgtPos, speed * Time.deltaTime, 0);
            transform.rotation = Quaternion.LookRotation(turRotation);

            if (Vector3.Distance(transform.position, target.position) <= 20 && !rolled)
            {
                missTgt();
                rolled = true;
            }
        }

        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
        }
        else if (lifetime <= 0)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void missTgt()
    {
        var missRng = Random.Range(0, 100);
        if (missRng <= 30)
        {
            target = null;
        }
    }

    public void lockTarget(Transform tgt)
    {
        target = tgt;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SendMessage("receiveDmg", 100);
        Destroy(gameObject);
    }
}
