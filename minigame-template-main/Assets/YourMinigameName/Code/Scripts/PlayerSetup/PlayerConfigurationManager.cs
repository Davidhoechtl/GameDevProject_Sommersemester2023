using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;

    [SerializeField]
    private List<Material> playerMaterials;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null)
        {
            /*GameObject[] configs = GameObject.FindGameObjectsWithTag("PlayerConfiguration");

            for(int i = 0; i < configs.Length; ++i)
            {
                Destroy(configs[i]);
            }*/
            Debug.LogError("More than one PlayerConfigurationManager");
            //Instance = null;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        playerConfigs = new List<PlayerConfiguration>();
        //playerMaterials = new List<Material>();
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log("Player joined " + pi.playerIndex);
        pi.transform.SetParent(transform);

        if(!playerConfigs.Any(player => player.PlayerIndex == pi.playerIndex))
        {
            playerConfigs.Add(new PlayerConfiguration(pi, playerMaterials[pi.playerIndex % 4]));
        }
    }

    public List<PlayerConfiguration> GetPlayerConfigurations()
    {
        return playerConfigs;
    }

}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi, Material material) 
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
        PlayerMaterial = material;
    }
    public PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public Material PlayerMaterial{ get; set; }
    
}
