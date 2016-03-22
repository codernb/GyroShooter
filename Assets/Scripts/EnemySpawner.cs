using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public Transform Player;
    public GameObject Compass;
    public GameObject Enemy;
    public GameObject NeedleConatiner;
    public float InitEnemyDelay = 5;
    public float EnemySpawnDistance = 60;
    public float EnemySpawnAngle = 0.4f;

    private float currentEnemyDelay;
    private float lastEnemySpawned;

    void Start()
    {
        lastEnemySpawned = Time.time;
        currentEnemyDelay = InitEnemyDelay;
    }

    void Update()
    {
        if (Time.time - lastEnemySpawned > currentEnemyDelay)
            SpawnEnemy();
    }

    private void SpawnEnemy()
    {

        

        var position = RandomPosition();
        var enemy = (GameObject) Instantiate(Enemy, position, Quaternion.identity);
        var enemyContainerController = enemy.GetComponent<EnemyContainerController>();
        enemyContainerController.Player = Player;
        lastEnemySpawned = Time.time;
        var needleContainer = (GameObject) Instantiate(NeedleConatiner, Compass.transform.position, Quaternion.identity);
        needleContainer.transform.parent = Compass.transform;
        needleContainer.transform.localPosition = new Vector3();
        needleContainer.GetComponent<NeedleContainerController>().Enemy = enemy.transform;
        enemyContainerController.NeedleContainer = needleContainer;
    }

    private Vector3 RandomPosition()
    {
        return new Vector3(RandomRange(1), RandomRange(EnemySpawnAngle), RandomRange(1)).normalized * EnemySpawnDistance;
    }

    private float RandomRange(float range)
    {
        return Random.Range(-range, range);
    }
}
