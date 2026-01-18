using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlertEnemy : MonoBehaviour
{
    public GameObject enemy;
    public string blockTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(blockTag))
        {
            enemy.GetComponent<EnemyScript>().block();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(blockTag))
        {
            enemy.GetComponent<EnemyScript>().block();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(blockTag))
        {
            Debug.Log("Not Blocking");
        }
    }
}
