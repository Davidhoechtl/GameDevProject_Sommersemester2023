using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class Lobby : MonoBehaviour
{
    public Image image;
    public TMP_Text playerText;
    private float swapTimer = 0;

    private void Update()
    {
        swapTimer -= Time.deltaTime;
    }

    public void JoinLobby(InputAction.CallbackContext ctx)
    {
        if(swapTimer <= 0)
        {
            image.GetComponent<Image>().color = new Color32(51, 255, 51, 255);
            playerText.text = "";
            Debug.Log("Joined Lobby");
            swapTimer = 1;
            MainMenu.Instance.IncreasePlayerCount();
        }
    }

    public void LeaveLobby(InputAction.CallbackContext ctx)
    {
        if(swapTimer <= 0)
        {
            image.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            playerText.text = "Press \"Rt\" to Join";
            Debug.Log("Leave Lobby");
            swapTimer = 1;
            MainMenu.Instance.DecreasePlayerCount();
        }
    }

}
