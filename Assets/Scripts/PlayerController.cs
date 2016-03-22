using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float TurnSpeed = 0.2f;
    public AudioClip DieSound;
    public float ShotDelay = 0.5f;
    public GameObject Shot;
    public Transform ShotSpawner;

    private Transform killer;
    private int shotVelocityMultipier = 40;
    private float randomValue = 0.02f;
    private float shotSpawnerYOffset = 0.5f;

    void Update()
    {
        if (killer == null)
            return;
        transform.rotation = Quaternion.LookRotation(killer.position - transform.position);
    }
    
    private float lastShot = 0;
    
    public void Shoot()
    {
        if (Time.time - lastShot < ShotDelay)
            return;
        Fire();
        lastShot = Time.time;
    }
    
    private void Fire()
    {
        var shotSpawnerPositionX = Random.Range(-randomValue, randomValue);
        var shotSpawnerPositionY = Random.Range(-randomValue, randomValue) - shotSpawnerYOffset;
        var shotSpawnPosition = new Vector3(ShotSpawner.position.x + shotSpawnerPositionX, ShotSpawner.position.y + shotSpawnerPositionY, ShotSpawner.position.z);
        var shot = (GameObject) Instantiate(Shot, shotSpawnPosition, ShotSpawner.rotation);
        shot.GetComponent<Rigidbody>().velocity = (ShotSpawner.position - transform.position).normalized * shotVelocityMultipier;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (killer != null)
            return;
        var other = collision.gameObject;
        var enemyController = other.GetComponent<EnemyController>();
        if (enemyController == null)
            return;
        enemyController.Stop = true;
        DisableGyroController();
        PlayDieSound(other);
        killer = other.transform;
        StartCoroutine(Restart());
    }

    private void DisableGyroController()
    {
        GetComponent<GyroControlled>().enabled = false;
    }

    private void PlayDieSound(GameObject audioSource)
    {
        var killerAudioSource = audioSource.GetComponent<AudioSource>();
        killerAudioSource.clip = DieSound;
        killerAudioSource.Play();
    }
    
    private IEnumerator Restart()
    {
        yield return new WaitForSeconds(3);
        Application.LoadLevel(Application.loadedLevel);
    }

}
