using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public Transform target;
    public GameObject missile;
    private GameObject newMissile;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(FireEnemy());
                Debug.Log("fired");
            }
    }

    IEnumerator FireEnemy()
    {
        newMissile = Instantiate(missile, transform.position, transform.rotation);
        newMissile.SendMessage("LockTarget", target.transform);
        yield return null;
    }

}
