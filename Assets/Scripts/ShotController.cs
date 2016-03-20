using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour
{

    void Update()
    {
        if (transform.position.y < - 500)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        var enemyController = collision.gameObject.GetComponent<PlayerController>();
        if (enemyController == null)
            Destroy(gameObject);
    }

}
