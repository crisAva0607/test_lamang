using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            if (isPaused) {
                Time.timeScale = 0; // Pauses the game
                // Disable any logic that shouldn't continue while paused
                // Display any necessary UI elements
                pausePanel.SetActive(true);
            } else {
                Time.timeScale = 1; // Unpauses the game
                // Re-enable any logic that was disabled while paused
                // Hide any displayed UI elements
                pausePanel.SetActive(false);
            }
        }
    }
}