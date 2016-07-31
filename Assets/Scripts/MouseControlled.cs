using UnityEngine;
using System.Collections;

public class MouseControlled : MonoBehaviour
{

	public GameObject Button;

    private PlayerController Player;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        Player = GetComponent<PlayerController>();
		Button.SetActive (false);
    }

    void Update()
    {
        var oldRotation = transform.rotation.eulerAngles;
        oldRotation.y += Input.GetAxis("Horizontal");
        oldRotation.x -= Input.GetAxis("Vertical");
        transform.rotation = Quaternion.Euler(oldRotation);
        if (Input.GetButton("Jump"))
            Player.Shoot();
    }
}
