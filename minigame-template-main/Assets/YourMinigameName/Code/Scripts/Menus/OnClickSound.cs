using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickSound : MonoBehaviour
{
    public AudioClip uiSound;
    public Button button;
    private AudioSource audioSource;

    private void Start()
    {
        button = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = uiSound;
        audioSource.playOnAwake = false;

        button.onClick.AddListener(PlaySoundOnClick);
    }

    private void PlaySoundOnClick()
    {
        audioSource.PlayOneShot(uiSound);
    }
}

