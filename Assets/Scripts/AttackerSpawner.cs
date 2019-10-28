using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{

    [SerializeField] Attacker[] enemyToSpawn;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;

    bool spawn = true;

    // Use this for initialization
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawner()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var enemy = Random.Range(0, enemyToSpawn.Length);
        Attacker newAttacker = Instantiate(enemyToSpawn[enemy], transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }
}
