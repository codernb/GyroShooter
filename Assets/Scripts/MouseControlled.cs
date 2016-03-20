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
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * 2);
        if (Input.GetButton("Fire1"))
            Player.Shoot();
    }
}
