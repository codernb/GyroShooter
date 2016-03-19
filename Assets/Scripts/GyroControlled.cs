using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GyroControlled : MonoBehaviour
{
    public float ShotDelay = 0.5f;
    public GameObject Shot;
    public Transform ShotSpawner;

    private Quaternion initialRotation;
    private Quaternion gyroInitialRotation;

    void Start()
    {
        Input.gyro.enabled = true;
        initialRotation = transform.rotation; 
    }

    void Update()
    {
        UpdateView();
        if (Input.touchCount > 0)
            Shoot();
    }

    private float lastShot = 0;

    public void Shoot()
    {
        if (Time.time - lastShot < ShotDelay)
            return;
        Fire();
        lastShot = Time.time;
    }

    private int shotVelocityMultipier = 40;
    private float randomValue = 0.02f;
    private float shotSpawnerYOffset = 0.5f;

    private void Fire()
    {
        var shotSpawnerPositionX = Random.Range(-randomValue, randomValue);
        var shotSpawnerPositionY = Random.Range(-randomValue, randomValue) - shotSpawnerYOffset;
        var shotSpawnPosition = new Vector3(ShotSpawner.position.x + shotSpawnerPositionX, ShotSpawner.position.y + shotSpawnerPositionY, ShotSpawner.position.z);
        var shot = (GameObject) Instantiate(Shot, shotSpawnPosition, ShotSpawner.rotation);
        shot.GetComponent<Rigidbody>().velocity = (ShotSpawner.position - transform.position).normalized * shotVelocityMultipier;
    }

    private void UpdateView()
    {
        Quaternion offsetRotation = gyroInitialRotation * Input.gyro.attitude;
        offsetRotation.z *= -1;
        offsetRotation.w *= -1;
        transform.rotation = initialRotation * offsetRotation;
    }

    public void Calibrate()
    {
        gyroInitialRotation = Quaternion.Inverse(Input.gyro.attitude);
    }

}
