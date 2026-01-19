using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    public GameObject ePrompt;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameText;
    public bool enemy;
    public GameObject wall;

    public int index;
    public GameManager gm;

    [TextArea]
    public string[] lines;
    public string[] nameL;

    private int currentLine = 0;
    private bool playerNearby = false;
    private bool dialogueActive = false;

    void Start()
    {
        gm = GetComponent<GameManager>();
    }

    void Update()
    {
        // Press E to start dialogue
        if (playerNearby && !dialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue();
        }

        // Press Space to advance dialogue
        if (dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            NextLine();
        }
    }

    void StartDialogue()
    {
        dialogueActive = true;
        currentLine = 0;

        dialoguePanel.SetActive(true);
        ePrompt.SetActive(false);
        dialogueText.text = lines[currentLine];
        nameText.text = nameL[currentLine];
    }

    void NextLine()
    {
        currentLine++;

        if (currentLine >= lines.Length && enemy == false)
        {
            EndDialogue();
        }
        else if (currentLine >= lines.Length && enemy == true)
        {
            EndDialogue();
            wall.SetActive(false);
            gm.StartFight(index, this);
        }
        else
        {
            dialogueText.text = lines[currentLine];
            nameText.text = nameL[currentLine];
        }
    }

    void EndDialogue()
    {
        dialogueActive = false;
        dialoguePanel.SetActive(false);

        if (playerNearby)
            ePrompt.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            ePrompt.SetActive(true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            ePrompt.SetActive(false);
            EndDialogue();
        }
    }
}
