using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class SetPlayerUI : MonoBehaviour
{
    private GameObject playerIcon;
    public PlayerInput input;
    public AudioClip uiSound;
    private AudioSource playerAudio;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.PlayOneShot(uiSound, 1.0f);
    }
    private void Awake()
    {
        playerIcon = GameObject.Find("Player" + (input.playerIndex + 1).ToString() + "_UI");
        playerIcon.transform.Find("PlayerImage").GetComponent<Image>().color = new Color32(51, 255, 51, 255);
        
        

    }
}
