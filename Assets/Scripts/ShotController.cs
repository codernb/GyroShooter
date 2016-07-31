using UnityEngine;
using System.Collections;

public class ShotController : MonoBehaviour
{

    public GameObject Explosion;
    public float Timer = 2;
    public SmokeTrailController SmokeTrail;
	public float Damage = 1;
	public float Speet = 1;

    //private Vector3 oldPosition;
    //private Quaternion rotation = new Quaternion();

    void Start()
    {
        //oldPosition = transform.position;
        StartCoroutine(TimedDestroy());
    }

    private IEnumerator TimedDestroy()
    {
        yield return new WaitForSeconds(Timer);
        Explode();
    }

    void Update()
    {/*
        if (oldPosition == transform.position)
            return;
        var dif = oldPosition - transform.position;
        rotation.SetLookRotation(dif);
        transform.localRotation = rotation;
        transform.Rotate(new Vector3(90, 0, 0));
        oldPosition = transform.position;*/
    }

    void OnCollisionEnter(Collision collision)
    {
		Explode();
    }

    private void Explode()
    {
		SmokeTrail.ReleaseFromShot();
		Instantiate(Explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
    }

}
