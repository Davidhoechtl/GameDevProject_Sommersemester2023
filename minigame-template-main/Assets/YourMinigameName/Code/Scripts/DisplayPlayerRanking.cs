using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPlayerRanking : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI NameText;
    [SerializeField]
    private TextMeshProUGUI PlacementText;
    [SerializeField]
    private GameObject PlayerModel;
    [SerializeField]
    private List<Material> playerMaterials;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerData(int id, int placement)
    {
        NameText.text = "Player " + id;
        PlayerModel.GetComponent<Renderer>().material = playerMaterials[id - 1];

        if(placement == 1)
        {
            PlacementText.text = "1st Place";
        }else if(placement == 2) 
        {
            PlacementText.text = "2nd Place";
        }
        else if (placement == 3)
        {
            PlacementText.text = "3rd Place";
        }
        else if (placement == 4)
        {
            PlacementText.text = "4th Place";
        }
        else
        {
            Debug.LogError("Placement out of bounds");
            PlacementText.text = "Error";
        }
        
    }
}
