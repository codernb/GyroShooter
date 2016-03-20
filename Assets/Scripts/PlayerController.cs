using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    public event EventHandler GameOver;
    public float TurnSpeed = 0.2f;
    public AudioClip DieSound;

    private Transform killer;

    void Update()
    {
        if (killer != null) {
            var finalRotation = Quaternion.LookRotation(killer.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, finalRotation, TurnSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (killer != null)
            return;
        var other = collision.gameObject;
        var enemyController = other.GetComponent<EnemyController>();
        if (enemyController == null)
            return;
        GetComponent<GyroControlled>().enabled = false;
        var killerAudioSource = other.GetComponent<AudioSource>();
        killerAudioSource.clip = DieSound;
        killerAudioSource.Play();
        killer = other.transform;
        GameOver.Invoke(this, null);
    }

}
