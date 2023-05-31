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

    //UI
    public int currentIndex = 0;
    private int arrayLength;
    private float swapTimer = 3;
    [SerializeField] Selectable[] uiComponents;

    private void Start()
    {
        arrayLength = uiComponents.Length;
    }

    private void Update()
    {
        swapTimer -= Time.deltaTime;
    }

    public void JoinLobby(InputAction.CallbackContext ctx)
    {
        //image.color = new Color(68, 153, 68, 1); // 20, 255, 12, 256
        image.GetComponent<Image>().color = new Color32(51, 255, 51, 255);
        playerText.text = "";
        Debug.Log("Joined Lobby");

    }

    public void LeaveLobby(InputAction.CallbackContext ctx)
    {
        image.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        playerText.text = "Press \"Rt\" to Join";
        Debug.Log("Leave Lobby");
    }

    public void IncreaseIndex(InputAction.CallbackContext ctx)
    {
        if (swapTimer <= 0)
        {
            currentIndex++;
            Debug.Log("Increased Index");
            if (currentIndex >= arrayLength)
            {
                currentIndex = 0;
            }
            uiComponents[currentIndex].Select();
            swapTimer = 3;
        }

    }

    public void DecreaseIndex(InputAction.CallbackContext ctx)
    {
        if (swapTimer <= 0)
        {
            currentIndex--;
            Debug.Log("Decreased Index");
            if (currentIndex < 0)
            {
                currentIndex = arrayLength - 1;
            }
            uiComponents[currentIndex].Select();
            swapTimer = 3;
        }

    }

}
