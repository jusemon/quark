using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningSystem : MonoBehaviour
{
    public Transform[] enemiesSpawningPoints;

    public Transform[] decorationSpawningPoints;

    public Transform[] powerUpsSpawningPoints;

    public GameObject[] enemies;

    public GameObject[] decorations;

    public GameObject[] powerUps;

    public int minSecondsToSpawnEnemies = 8;

    public int maxSecondsToSpawnEnemies = 16;

    public int minSecondsToSpawnDecorations = 4;

    public int maxSecondsToSpawnDecorations = 9;

    public int minSecondsToSpawnPowerUps = 15;

    public int maxSecondsToSpawnPowerUps = 20;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn(enemies, enemiesSpawningPoints, minSecondsToSpawnEnemies, maxSecondsToSpawnEnemies));

        StartCoroutine(Spawn(decorations, decorationSpawningPoints, minSecondsToSpawnDecorations, maxSecondsToSpawnDecorations));

        StartCoroutine(Spawn(powerUps, powerUpsSpawningPoints, minSecondsToSpawnPowerUps, maxSecondsToSpawnPowerUps));
    }

    IEnumerator Spawn(GameObject[] objects, Transform[] spawningPoints, int minSeconds, int maxSeconds)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSeconds, maxSeconds));

            Instantiate(
                objects[Random.Range(0, objects.Length)],
                spawningPoints[Random.Range(0, spawningPoints.Length)].position, Quaternion.identity
                );
        }
    }
}
