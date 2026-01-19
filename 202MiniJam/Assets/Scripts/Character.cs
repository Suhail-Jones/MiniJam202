using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class Character : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive())
            Debug.Log("Dead");
    }

    public Boolean isAlive()
    {
        return currentHealth > 0; 
    }

    public void decreaseHealth(float damage)
    {
        currentHealth -= damage;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Untagged")
        {
            Debug.Log(col.gameObject.tag + " detected");
        }
        if(col.gameObject.tag == "Player")
        {
            decreaseHealth(col.gameObject.GetComponent<PlayerMovement>().hand.GetComponent<DamagingObject>().getDamage());
            Debug.Log(col.gameObject.tag + " damaged");
        }

        if (col.gameObject.CompareTag("Hand") || col.gameObject.CompareTag("Spell") || col.gameObject.CompareTag("Ultimate"))
        {
            decreaseHealth(col.gameObject.GetComponent<DamagingObject>().getDamage());
            Debug.Log(col.gameObject.tag + " damaged");
        }
    }
}
