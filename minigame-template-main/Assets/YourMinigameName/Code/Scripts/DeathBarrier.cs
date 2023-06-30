using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    public AudioClip deathSound;
    public ParticleSystem circleEffect;
    public ParticleSystem splashEffect;
    private AudioSource groundSensorAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayDeathSound();
            SpawnDeathEffect(other.transform.position);
            Destroy(other.gameObject);
            GameHandler.Instance.Invoke("CheckIfGameOver", 1);
        }
    }

    private void PlayDeathSound()
    {
        groundSensorAudioSource.PlayOneShot(deathSound);
    }

    private void SpawnDeathEffect(Vector3 position)
    {
        Instantiate(circleEffect, position, Quaternion.identity);
        Instantiate(splashEffect, position, Quaternion.identity);
    }
}
