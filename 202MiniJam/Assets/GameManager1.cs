using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{
    public GameObject player;
    public PlayerMovement playerS;
    public string endLine;
    public bool fightEnd = false;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    private int index;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

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
            
        }

        // Fight
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            GameObject enemyHealthBar = GameObject.Find("Evil Health Bar");
            HealthBar ehb = enemyHealthBar.GetComponent<HealthBar>();

            GameObject enemy = GameObject.FindWithTag("Enemy");
            int enemyHealth = (int) enemy.GetComponent<Character>().currentHealth;

            GameObject playerHealthBar = GameObject.Find("Health Bar");
            HealthBar hb = playerHealthBar.GetComponent<HealthBar>();

            GameObject player = GameObject.FindWithTag("Player");
            int playerHealth = (int) player.GetComponent<Character>().currentHealth;

            ehb.SetHealth(enemyHealth);
            hb.SetHealth(playerHealth);

            if (index == 1)
            {
                Instantiate(enemy1, new Vector3(), Quaternion.identity);
            }
            else if (index == 2)
            {
                Instantiate(enemy2, new Vector3(), Quaternion.identity);
            }
            else if (index == 3)
            {
                Instantiate(enemy3, new Vector3(), Quaternion.identity);
            }
            else if (index == 4)
            {
                Instantiate(enemy4, new Vector3(), Quaternion.identity);
            }
            else
            {
                Instantiate(enemy5, new Vector3(), Quaternion.identity);
            }

            if (fightEnd)
            {
                fightEnd = false;
                SceneManager.UnloadSceneAsync(3);

                GameObject gameplayRoot = GameObject.Find("GameplayRoot");
                gameplayRoot.SetActive(true);
            }
        }

        // Coin Flip
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            float countdown = 3f;

            countdown = countdown - Time.deltaTime;

            if (countdown < 0)
            {
                int rand = Random.Range(0, 2);

                if (rand == 0)
                {
                    SceneManager.LoadScene(5, LoadSceneMode.Additive);
                    SceneManager.UnloadSceneAsync(4);
                }
                else
                {
                    SceneManager.LoadScene(6, LoadSceneMode.Additive);
                    SceneManager.UnloadSceneAsync(4);
                }
            }
        }

        // Win Screen
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            float countdown = 3f;

            countdown = countdown - Time.deltaTime;

            if (countdown < 0)
            {
                GameObject gameplayRoot = GameObject.Find("GameplayRoot");
                gameplayRoot.SetActive(true);
                SceneManager.UnloadSceneAsync(5);
            }
        }

        // Loss Screen
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            float countdown = 3f;

            countdown = countdown - Time.deltaTime;

            if (countdown < 0)
            {
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
                SceneManager.UnloadSceneAsync(5);
            }
        }
    }

    public void StartFight(int index1, Interaction goS)
    {
        index = index1;

        if (index1 == 1)
        {
            endLine = "You may have bested me, but there is more to come..";
        }
        else if (index1 == 2)
        {
            endLine = "Just wait..till I get..my hands..on you";
        }
        else if (index1 == 3)
        {
            endLine = "W-where did you get all that power from..";
        }
        else if (index1 == 4)
        {
            endLine = "The boss won't be happy about this..";
        }

        for (int i = 0; i < goS.lines.Length; i++)
        {
            if (i == 0)
            {
                goS.lines[i] = endLine;
            }
            else
            {
                goS.lines[i] = null;
            }
        }

        SceneManager.LoadScene(4, LoadSceneMode.Additive);

        GameObject gameplayRoot = GameObject.Find("GameplayRoot");
        gameplayRoot.SetActive(false);
    }
}
