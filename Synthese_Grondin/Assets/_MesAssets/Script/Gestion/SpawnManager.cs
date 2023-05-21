using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyShipPrefab = default;
    [SerializeField] private GameObject enemyTurretPrefab = default;
    [SerializeField] private GameObject enemyContainer = default;
    private bool stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyShipRoutine());
        StartCoroutine(SpawnEnemyTurretRoutine());
    }

    IEnumerator SpawnEnemyShipRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        while (!stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(10f, -24f), Random.Range(16.5f, -18f), 0f);
            GameObject newEnemy = Instantiate(enemyShipPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(2.0f);
        }
    }

    IEnumerator SpawnEnemyTurretRoutine()
    {
        yield return new WaitForSeconds(4.0f);
        while (!stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(10f, -24f), Random.Range(16.5f, -18f), 0f);
            GameObject newEnemy = Instantiate(enemyTurretPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(8.0f);
        }
    }

    public void OnPlayerDeath()
    {
        stopSpawning = true;
    }
}
