using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public Transform PlayerPosition;
    public float InitialEnemySpeed;

    private float currentEnemySpeed;

    void Start()
    {
        currentEnemySpeed = InitialEnemySpeed;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, PlayerPosition.position, currentEnemySpeed);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        var shotController = collision.gameObject.GetComponent<ShotController>();
        if (shotController != null)
            Destroy(gameObject);
    }

}
