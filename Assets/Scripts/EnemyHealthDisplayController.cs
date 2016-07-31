using UnityEngine;
using System.Collections;

public class EnemyHealthDisplayController : MonoBehaviour {

	public Camera PlayerCamera;
	public TextMesh EnemyHealthText;
	
	void Update () {
		RaycastHit hit;
		var cameraCenter = PlayerCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, PlayerCamera.nearClipPlane));
		if (Physics.Raycast (cameraCenter, this.transform.forward, out hit, 1000)) {
			var enemyController = hit.transform.gameObject.GetComponent<EnemyController> ();
			if (enemyController != null)
				EnemyHealthText.text = enemyController.CurrentLife.ToString ();
			else
				EnemyHealthText.text = "";
		}
		else
			EnemyHealthText.text = "";
	}
}
