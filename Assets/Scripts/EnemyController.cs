using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    public GameObject RadarPlane;
    public float Speed { get; set; }
	public float Life;
	public int Value = 10;

	public float CurrentLife { get; set; }
	private Rigidbody RigidBody;

    void Start()
    {
		CurrentLife = Life;
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
		var ShotController = collision.gameObject.GetComponent<ShotController> ();
		if (ShotController == null)
			return;
		GetDamage (ShotController);
    }

	private void GetDamage(ShotController shotController) {
		var newLife = CurrentLife - shotController.Damage;
		if (newLife > 0)
			CurrentLife = newLife;
		else
			Die ();
	}

	private void Die() {
		CurrentLife = 0;
		RadarPlane.SetActive(false);
		RigidBody.useGravity = true;
		RigidBody.isKinematic = false;
		Debug.Log (RigidBody.isKinematic);
	}

}
