using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

/// <summary>
/// Singleton Monobehaviour, use MenuHandler.Instance
/// </summary>
public class MenuHandler : MonoBehaviour
{
    public enum MenuType { Pause, Win, Lose }

    public static MenuHandler Instance { get; private set; }

    [SerializeField]
    GameObject
        PauseMenu;
       // LoseMenu,
        //WinMenu;

    public bool MenuIsOpen => allMenus.Where(predicate: (KeyValuePair<MenuType, GameObject> menuPair) => menuPair.Value.activeSelf).Any();

    private Dictionary<MenuType, GameObject> allMenus;


    void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("multiple instances of MenuHandler in scene " + this.name);
        }
        Instance = this;

        allMenus = new()
        {
            { MenuType.Pause, PauseMenu }
            //{ MenuType.Lose, LoseMenu },
            //{ MenuType.Win, WinMenu }
        };
    }

    private void Update()
    {
        
    }

    public void OpenMenu(MenuType menuType = MenuType.Pause)
    {
        Time.timeScale = 0f;
        foreach (var pair in allMenus)
        {
            var menuObject = pair.Value;
            if (menuObject.activeSelf)
            {
                menuObject.SetActive(false);
            }
        }
        allMenus[menuType].SetActive(true);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1f;
        foreach (var pair in allMenus)
        {
            var menuObject = pair.Value;
            menuObject.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        Debug.Log("resuming game");
        CloseMenu();
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (MenuIsOpen && allMenus[MenuType.Pause].activeSelf)
        {
            ResumeGame();
        }
        else if (!MenuIsOpen)
        {
            Debug.Log("Game Paused");
            OpenMenu(MenuType.Pause);
            Time.timeScale = 0f;
        }
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
