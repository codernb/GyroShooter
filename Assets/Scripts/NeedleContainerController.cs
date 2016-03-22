using UnityEngine;
using System.Collections;

public class NeedleContainerController : MonoBehaviour
{

    public Transform Enemy { get; set; }

    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Enemy.position - transform.position);
    }
}
