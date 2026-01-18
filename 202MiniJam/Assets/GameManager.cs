using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Intro Screen of the game
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            // Exit Game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

            // Load Instructions
            if (Input.GetKeyDown(KeyCode.I))
            {
                SceneManager.LoadScene(1);
            }

            // Load Game
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(2);
            }
        }

        // Instructions Screen
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            // Load Intro Screen again
            if (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(0);
            }

            // Continue to Game
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(2);
            }
        }

        // Main Game
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            // Fill in as main game is made
        }
    }
}
