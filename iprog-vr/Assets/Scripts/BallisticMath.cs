using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticMath : MonoBehaviour
{
    public int damage;
    public bool isMissile;
    public GameObject missile;

    private GameObject newMissile;

    private float countdown = 0f;
    private bool isFire;

    private TurretRotate tR;
    private GameObject target;
    private RaycastHit hitTarget;

    private List<ParticleSystem> bulletParticles = new List<ParticleSystem>();

    // Start is called before the first frame update
    void Start()
    {
        isFire = false;
        tR = transform.parent.GetComponent<TurretRotate>();
        bulletParticles.AddRange(GetComponentsInChildren<ParticleSystem>());
    }

    // Update is called once per frame
    void Update()
    {
        target = tR.target;
        if (target != null)
        {
            FireControl();
        }
        else
        {
            isFire = false;
            foreach (ParticleSystem bulletParticle in bulletParticles)
            {
                bulletParticle.Play();
            }
        }
    }

    private void FireControl()
    {
        if (!isMissile)
        {
            Debug.DrawRay(transform.position, transform.forward * Vector3.Distance(transform.position, target.transform.position));
            if (Physics.Raycast(transform.position, transform.forward * Vector3.Distance(transform.position, target.transform.position), out hitTarget))
            {
                isFire = true;
            }
            else
            {
                isFire = false;
            }
        }

        else if (isMissile)
        {
            isFire = true;
        }
        

        if (isFire)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                StartCoroutine(Fire());
                countdown = 4f;
            }
            else if (countdown > 0)
            {
                StopCoroutine(Fire());
            }
        }
    }

    IEnumerator Fire()
    {
        if (!isMissile)
        {
            for(var i=0; i < 4; i++)
            {
                hitTarget.transform.SendMessage("receiveDmg", 25);
                Debug.Log("pew");
                foreach (ParticleSystem bulletParticle in bulletParticles)
                {
                    bulletParticle.Play();
                }
                yield return new WaitForSeconds(1);
            }
        }
        else if (isMissile)
        {
            newMissile = Instantiate(missile, transform.position, transform.rotation);
            newMissile.SendMessage("lockTarget", target.transform);
            Debug.Log("whoosh");
        }
    }
}
