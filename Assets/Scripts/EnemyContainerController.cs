using UnityEngine;
using System.Collections;

public class EnemyContainerController : MonoBehaviour
{

    public Transform Player { get; set; }
    public bool Stop { get; set; }
    public float InitialEnemySpeed;
    public GameObject NeedleContainer { get; set; }

    private float currentEnemySpeed;

    void Start()
    {
        currentEnemySpeed = InitialEnemySpeed;
    }

    void FixedUpdate()
    {
        if (Stop)
            return;
        transform.position += (Player.position - transform.position).normalized * currentEnemySpeed;
    }

    void OnDestroy()
    {
        Destroy(NeedleContainer);
    }

}
