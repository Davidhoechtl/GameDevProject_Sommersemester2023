using Assets.YourMinigameName.Code.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrier : MonoBehaviour
{
    public AudioClip deathSound;
    public ParticleSystem circleEffect;
    public ParticleSystem splashEffect;
    private AudioSource groundSensorAudioSource;

    private void Start()
    {
        groundSensorAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayDeathSound();
            SpawnDeathEffect(other.transform.position);
            PlayerController controller = other.gameObject.GetComponent<PlayerController>();
            controller.DeletePlayer();
            //Destroy(other.gameObject);
            GameHandler.Instance.Invoke("CheckIfGameOver", 1);
        }
    }

    private void PlayDeathSound()
    {
        groundSensorAudioSource.PlayOneShot(deathSound, 1.0f);
        
    }

    private void SpawnDeathEffect(Vector3 position)
    {
        
        Quaternion rotation = Quaternion.Euler(-90f, 0f, 0f); // Adjust the rotation as needed
        ParticleSystem instantiatedCircleEffect = Instantiate(circleEffect, position, rotation);
        ParticleSystem instantiatedSplashEffect = Instantiate(splashEffect, position, rotation);
        Vector3 adjustedPosition = new Vector3(position.x, position.y + 5f, position.z);
        instantiatedCircleEffect.transform.position = adjustedPosition;
        instantiatedSplashEffect.transform.position = adjustedPosition;
    }
}
