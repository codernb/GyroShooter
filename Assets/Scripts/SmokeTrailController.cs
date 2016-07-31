using UnityEngine;
using System.Collections;

public class SmokeTrailController : MonoBehaviour
{

    public ParticleSystem Smoke;

    public void ReleaseFromShot()
    {
		var emission = Smoke.emission;
		emission.enabled = false;
        transform.parent = null;
        Destroy(gameObject, 5);
    }

}
