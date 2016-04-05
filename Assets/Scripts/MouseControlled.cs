using UnityEngine;
using System.Collections;

public class MouseControlled : MonoBehaviour
{

    private PlayerController Player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Player = GetComponent<PlayerController>();
    }

    void Update()
    {
        var oldRotation = transform.rotation.eulerAngles;
        oldRotation.y += Input.GetAxis("Horizontal");
        oldRotation.x -= Input.GetAxis("Vertical");
        transform.rotation = Quaternion.Euler(oldRotation);
        if (Input.GetButton("Fire1"))
            Player.Shoot();
    }
}
