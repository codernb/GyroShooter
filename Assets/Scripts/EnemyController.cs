using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public float TorqueForce = 20;
    public GameObject Container;
    public AudioSource FlickerAudioSource;

    private Rigidbody RigidBody;
    private MeshRenderer Meshrenderer;

    void Start()
    {
        RigidBody = GetComponent<Rigidbody>();
        Meshrenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (Random.value > 0.9f)
            StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        Meshrenderer.enabled = false;
        FlickerAudioSource.Play();
        yield return new WaitForSeconds(0.1f);
        Meshrenderer.enabled = true;
        FlickerAudioSource.Stop();
    }
	
    void FixedUpdate()
    {
        RigidBody.AddTorque(Random.insideUnitSphere * TorqueForce);
        transform.localPosition = Random.insideUnitSphere * 0.2f;
    }
    
    void OnCollisionEnter(Collision collision)
    {
        var shotController = collision.gameObject.GetComponent<ShotController>();
        if (shotController != null)
            Destroy(Container);
    }
}
