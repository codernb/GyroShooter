using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GyroControlled : MonoBehaviour
{

    private Quaternion initialRotation;
    private Quaternion gyroInitialRotation;
    private PlayerController Player;

    void Start()
    {
        Input.gyro.enabled = true;
        initialRotation = transform.rotation; 
        Player = GetComponent<PlayerController>();
    }

    void Update()
    {
        UpdateView();
        if (Input.touchCount > 0)
            Player.Shoot();
    }

    private void UpdateView()
    {
        Quaternion offsetRotation = gyroInitialRotation * Input.gyro.attitude;
        offsetRotation.z *= -1;
        offsetRotation.w *= -1;
        transform.rotation = initialRotation * offsetRotation;
    }

    public void Calibrate()
    {
        gyroInitialRotation = Quaternion.Inverse(Input.gyro.attitude);
    }

}
