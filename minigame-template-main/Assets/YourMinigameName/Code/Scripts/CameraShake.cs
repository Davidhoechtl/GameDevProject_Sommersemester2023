using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float shakeAmount = 7f; // The amount of camera shake
    public float shakeSpeed = 10f; // The speed at which the camera shakes

    private Vector3 originalPos; // The original position of the camera

    void Start()
    {
        originalPos = transform.localPosition; // Store the original position of the camera
    }

    void Update()
    {
        float bass = GetComponent<AudioSource>().GetSpectrumData(1024, 0, FFTWindow.BlackmanHarris)[1]; // Extract the bass data from the audio source
        float shake = Mathf.Pow(bass, 2) * shakeAmount; // Map the bass data to the camera shake effect

        transform.localPosition = originalPos + Random.insideUnitSphere * shake; // Apply the camera shake effect
    }
}

