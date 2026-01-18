using UnityEngine;
using TMPro;

public class SignInteraction : MonoBehaviour
{
    public GameObject ePrompt;
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;

    [TextArea]
    public string[] lines;

    private int currentLine = 0;
    private bool playerNearby = false;
    private bool dialogueActive = false;

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
    }

    void NextLine()
    {
        currentLine++;

        if (currentLine >= lines.Length)
        {
            EndDialogue();
        }
        else
        {
            dialogueText.text = lines[currentLine];
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
        Debug.Log("Triggered by: " + other.name);

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
