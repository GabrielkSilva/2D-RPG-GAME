using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;
    public Transform player;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[randomSpawnIndex].transform.position;
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Define a referência do jogador no script EnemyMovement do inimigo instanciado
        EnemyMovement enemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();
        enemyMovement.player = player;
    }
}
