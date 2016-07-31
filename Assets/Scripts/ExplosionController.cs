using UnityEngine;
using System.Collections;

public class ExplosionController : MonoBehaviour {

	public float LivingTime = 1;
	public float GrowRate = 1.2f;

	private Vector3 Scale = Vector3.one;

	void Start () {
		StartCoroutine (Die ());
	}

	private IEnumerator Die() {
		yield return new WaitForSeconds (LivingTime);
		Destroy (gameObject);
	}
	
	void Update () {
		Scale *= GrowRate;
		transform.localScale = Scale;
	}
}
