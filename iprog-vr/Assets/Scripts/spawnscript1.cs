using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnscript : MonoBehaviour
{
    public GameObject enemy;
    public int maxEnemy;
    public int gap;
    public int spawnCount = 0;
    public int maxSpawn;
    public GameObject enemycount;

    void Update()
    {
        if (spawnCount < maxSpawn)
        {
            StartCoroutine(Spawn());
            spawnCount++;
        }
        enemycount = GameObject.FindGameObjectWithTag("enemy");
        if (enemycount == null)
        {
            --spawnCount;
            if (spawnCount < maxSpawn)
            {
                StartCoroutine(Spawn());
                spawnCount++;
            }
        }
    }

    IEnumerator Spawn()
    {
            for (int z = 0; z < maxEnemy; z++)
            {
                GameObject block = Instantiate(enemy, Vector3.zero, enemy.transform.rotation);
                block.transform.parent = transform;
                block.transform.localPosition = new Vector3(0, z * gap, 0);
                yield return new WaitForSeconds(5f);
            }
            yield return null;
    }
}

