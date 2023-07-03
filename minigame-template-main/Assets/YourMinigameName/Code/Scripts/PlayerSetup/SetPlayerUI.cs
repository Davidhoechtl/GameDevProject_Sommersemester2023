using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class SetPlayerUI : MonoBehaviour
{
    private GameObject playerUI;
    public PlayerInput input;

    [SerializeField]
    private List<Material> playerMaterials;

    private void Awake()
    {
        playerUI = GameObject.Find("Player" + (input.playerIndex + 1).ToString() + "_UI");
        playerUI.transform.Find("PlayerImage").GetComponent<Image>().color = playerMaterials[input.playerIndex % 4].color;
        playerUI.transform.Find("PlayerText").GetComponent<TextMeshProUGUI>().text = "Player " + (input.playerIndex + 1).ToString();
    }
}
