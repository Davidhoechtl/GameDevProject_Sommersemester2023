using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float initialShakeAmount = 7f; // The initial amount of camera shake
    public float shakeSpeed = 10f; // The speed at which the camera shakes
    public float shakeIncreaseRate = 0.1f; // The rate at which the shake amount increases over time

    private Vector3 originalPos; // The original position of the camera
    private AudioSource audioSource; // The AudioSource attached to the main camera
    private float elapsedTime = 0f; // Elapsed time since the start of the game
    private float shakeMultiplier = 1f; // The shake multiplier

    void Start()
    {
        originalPos = transform.localPosition; // Store the original position of the camera
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource attached to the main camera
    }

    void Update()
    {
        elapsedTime += Time.deltaTime; // Update the elapsed time

        float bass = GetBassValue(); // Extract the bass data from the audio source
        float shake = Mathf.Pow(bass, 2) * initialShakeAmount * shakeMultiplier; // Map the bass data to the camera shake effect

        transform.localPosition = originalPos + Random.insideUnitSphere * shake; // Apply the camera shake effect

        // Increase the shake multiplier over time
        shakeMultiplier = 1f + shakeIncreaseRate * elapsedTime;
    }

    float GetBassValue()
    {
        if (audioSource != null)
        {
            float[] spectrumData = new float[1024];
            audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
            return spectrumData[1];
        }

        return 0f;
    }
}
