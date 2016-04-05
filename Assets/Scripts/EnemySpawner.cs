using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Enemy;
    public float EnemyDelay = 2;
    public float MinEnemyHeight = 10;
    public float MaxEnemyHeight = 50;
    public float EnemySpeed = 10;
    public float EnemyDistance = 300;
    public float RandomDirection = 10;

    private float LastEnemySpawned = float.MinValue;
    private int EnemyCounter;

    void Update()
    {
        if (Time.time - LastEnemySpawned < EnemyDelay)
            return;
        EnemyCounter++;
        var randomDir = Random.insideUnitCircle.normalized * EnemyDistance;
        var enemyPosition = new Vector3(randomDir.x, Random.Range(MinEnemyHeight, MaxEnemyHeight), randomDir.y);
        var enemy = (GameObject) Instantiate(Enemy, enemyPosition, Quaternion.LookRotation(new Vector3(-enemyPosition.x + Random.Range(-RandomDirection, RandomDirection), 0, -enemyPosition.z + Random.Range(-RandomDirection, RandomDirection))));
        enemy.GetComponent<EnemyController>().Speed = EnemySpeed + Random.Range(Mathf.Max(0f, EnemyCounter - 10), EnemyCounter);
        LastEnemySpawned = Time.time;
    }
}
