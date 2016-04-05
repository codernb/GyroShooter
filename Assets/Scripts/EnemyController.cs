using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public GameObject RadarPlane;
    public float Speed { get; set; }

    private Rigidbody RigidBody;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
        RigidBody.velocity = transform.forward * Speed;
    }

    void Update()
    {
        if (transform.position.y < -30)
            Destroy(gameObject);
    }
    
    void OnCollisionEnter(Collision collision)
    {
        RadarPlane.SetActive(false);
        RigidBody.useGravity = true;
    }

}
