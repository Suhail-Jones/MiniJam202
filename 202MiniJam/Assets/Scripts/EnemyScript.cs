using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject field;
    public bool isStunned = false;

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

    IEnumerator Freeze(float duration)
    {
        // Set stunned state
        isStunned = true;

        // Wait for the stun duration
        yield return new WaitForSeconds(duration);

        // End stun
        isStunned = false;
    }


    public void block()
    {
        Debug.Log("Blocking");
    }

}
