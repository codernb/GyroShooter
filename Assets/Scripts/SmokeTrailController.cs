using UnityEngine;
using System.Collections;

public class SmokeTrailController : MonoBehaviour
{

    public ParticleSystem Smoke;

    public void ReleaseFromShot()
    {
        Smoke.enableEmission = false;
        transform.parent = null;
        Destroy(gameObject, 5);
    }

}
