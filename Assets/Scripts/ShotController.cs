using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour
{

    void Update()
    {
        if (transform.position.y < - 500)
            Destroy(gameObject);
    }
}
