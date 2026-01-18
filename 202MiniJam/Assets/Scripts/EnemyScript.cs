using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject field;

    // Update is called once per frame
    void Update()
    {
        // Attacks
        int attackChoice = Random.Range(0, 3);

        // Attack Basic
        if (attackChoice == 0)
        {
            // Throw basic attack
        }
        else if (attackChoice == 1)
        {
            // Throw heavy attack
        }
        else if (attackChoice == 2)
        {
            // Fire spell
        }
        else if (attackChoice == 3)
        {
            // Do nothing
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spell")
        {
            // Trigger blocking
            Debug.Log("Blocking");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spell")
        {
            // Continued Blocking
            Debug.Log("Still Blocking");
        }
    }
}
