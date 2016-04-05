using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float ShotDelay = 0.5f;
    public GameObject Shot;
    public Transform ShotSpawner;
    public int shotVelocityMultipier = 120;
    public float randomValue = 10;

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
        var shot = (GameObject) Instantiate(Shot, ShotSpawner.position, ShotSpawner.rotation);
        shot.transform.Rotate(getRandomShotDirection());
        shot.GetComponent<Rigidbody>().velocity = shot.transform.up * shotVelocityMultipier;
    }

    private Vector3 getRandomShotDirection()
    {
        return new Vector3(Random.Range(-randomValue, randomValue), 0, Random.Range(-randomValue, randomValue));
    }

}
