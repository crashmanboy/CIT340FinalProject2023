using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<SpawnGroup> spawnGroups;
    void Start()
    {
        StartCoroutine(spawnEnemies());
    }

    IEnumerator spawnEnemies()
    {
        for(int i = 0; i < spawnGroups.Count; i++)
        {
            for(int j = 0; j < spawnGroups[i].num; j++)
            {
                Instantiate(spawnGroups[i].enemy, WaypointManager.pointList[0], Quaternion.identity);
                yield return new WaitForSeconds(spawnGroups[i].spawnDelay);
            }
            yield return new WaitForSeconds(spawnGroups[i].groupDelay);
        }
    }
}
[Serializable]
public struct SpawnGroup
{
    public GameObject enemy;
    public int num;
    public float spawnDelay;
    public float groupDelay;
}
