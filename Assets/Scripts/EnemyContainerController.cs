using UnityEngine;
using System.Collections;

public class EnemyContainerController : MonoBehaviour
{

    public Transform Player;
    public float InitialEnemySpeed;

    private float currentEnemySpeed;

    void Start()
    {
        currentEnemySpeed = InitialEnemySpeed;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Player.position, currentEnemySpeed);
    }

}
