using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrobeLight : MonoBehaviour
{
    private float beatThreshold = 1f; // The amplitude threshold for triggering the strobe light effect
    private float strobeDuration = 0.5f; // The duration of each strobe light cycle
    private float bassThreshold = -8f; // The amplitude threshold for triggering the bass effect
    private float bassMultiplier = 100f; // The multiplier to apply to the bass amplitude
    public Light light; // The light component to be strobed

    private float strobeTimer = 0f; // The current timer for the strobe effect

    void Update()
    {
        // Get the spectrum data
        float[] spectrumData = new float[256];
        AudioListener.GetSpectrumData(spectrumData, 0, FFTWindow.Hamming);

        // Get the amplitude of the bass frequencies
        float bassAmplitude = 0f;
        for (int i = 1; i < 4; i++)
        {
            bassAmplitude += spectrumData[i];
        }
        bassAmplitude /= 3f;

        // Determine whether the strobe light should be turned on or off
        if (bassAmplitude > bassThreshold)
        {
            light.intensity = bassAmplitude * bassMultiplier * 2 ;
        }
        else
        {
            light.intensity = 0f;
        }

        // Update the strobe timer and toggle the light if necessary
        strobeTimer += Time.deltaTime;
        if (strobeTimer >= strobeDuration)
        {
            light.enabled = !light.enabled;
            strobeTimer = 0f;
        }
    }
}
