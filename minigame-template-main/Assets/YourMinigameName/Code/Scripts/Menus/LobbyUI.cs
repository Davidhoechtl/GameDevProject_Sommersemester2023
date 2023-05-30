using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class LobbyUI : MonoBehaviour
{
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

    public void IncreaseIndex(InputAction.CallbackContext ctx)
    {
        if(swapTimer <= 0)
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
        if(swapTimer <= 0)
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
