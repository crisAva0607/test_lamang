using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] Button _mainMenu;

    void Start()
    {
        _mainMenu.onClick.AddListener(LoadMainMenu);        
    }

    private void LoadMainMenu()
    {
        ScenesManager.Instance.LoadMainMenu();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1; // Unpauses the game
    }
}
