using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotate : MonoBehaviour
{
    private float speed = 3f;
    public GameObject target;
    private TurretRotate tR;

    // Start is called before the first frame update
    void Start()
    {
        tR = gameObject.GetComponentInParent<TurretRotate>();
    }

    // Update is called once per frame
    void Update()
    {
        target = tR.target;
        if (target != null)
        {
            Vector3 tgtPos = target.transform.position - transform.position;
            Vector3 gunRotation = Vector3.RotateTowards(transform.forward, tgtPos, speed * Time.deltaTime, 0);
            var lookDir = Quaternion.LookRotation(gunRotation);
            transform.localRotation = Quaternion.Euler(lookDir.eulerAngles.x, 0,0);
        }
    }
}
