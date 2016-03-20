using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    public GameObject Enemy;
    public GameObject Player;
    public float InitEnemyDelay = 5;
    public float EnemySpawnDistance = 60;

    private float currentEnemyDelay;
    private float lastEnemySpawned;

    void Start()
    {
        currentEnemyDelay = InitEnemyDelay;
        Player.GetComponent<PlayerController>().GameOver += delegate {
            StartCoroutine(Restart());
        };
    }

    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel(Application.loadedLevel);
    }

    void Update()
    {
        if (Time.time - lastEnemySpawned < currentEnemyDelay)
            return;
        var position = Random.insideUnitSphere * EnemySpawnDistance;
        GameObject enemy = (GameObject) Instantiate(Enemy, position, Quaternion.identity);
        enemy.GetComponent<EnemyController>().PlayerPosition = Player.transform;
        lastEnemySpawned = Time.time;
    }
}
