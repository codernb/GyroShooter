using UnityEngine;
using System.Collections;

public class SunController : MonoBehaviour
{

    public float Speed = 0.1f;

    void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(2 * Speed, 1 * Speed, 0);
    }
	
}
