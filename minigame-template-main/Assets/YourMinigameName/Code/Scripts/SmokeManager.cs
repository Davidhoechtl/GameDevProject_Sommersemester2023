using UnityEngine;

public class SmokeManager : MonoBehaviour
{
    public float delay = 10f;
    private bool isHidden = true;
    public AudioClip soundClip;
    private AudioSource audioSource;

    private void Start()
    {
        // Hide the object initially
        SetVisibility(false);
        audioSource = GetComponent<AudioSource>();

        // Invoke the method to show the object after the delay
        Invoke("ShowObject", delay);
    }

    private void SetVisibility(bool isVisible)
    {
        // Set the visibility of the object
        gameObject.SetActive(isVisible);
        isHidden = !isVisible;
    }

    private void ShowObject()
    {
        // Show the object if it is still hidden
        if (isHidden)
        {
            SetVisibility(true);
            if (soundClip != null && audioSource != null)
            {
                audioSource.clip = soundClip;
                audioSource.Play();
            }
        }
    }
}
