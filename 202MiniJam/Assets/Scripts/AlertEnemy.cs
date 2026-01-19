using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlertEnemy : MonoBehaviour
{
    public GameObject enemy;
    public string blockTag;
    public GameObject player;
    public string block;

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
            if(collision.gameObject.tag == "Hand" && collision.gameObject.GetComponent<DamagingObject>().getDamage() > 0)
            {
                enemy.GetComponent<EnemyScript>().block();
            }
            else if(collision.gameObject.tag != "Hand")
            {
                enemy.GetComponent<EnemyScript>().block();
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(blockTag))
        {
            if (collision.gameObject.tag == "Hand" && collision.gameObject.GetComponent<DamagingObject>().getDamage() > 0)
            {
                enemy.GetComponent<EnemyScript>().block();
                block = "Blocking";
            }
            else if (collision.gameObject.tag != "Hand")
            {
                enemy.GetComponent<EnemyScript>().block();
                block = "Blocking";
            }
            else if (collision.gameObject.GetComponent<DamagingObject>().getDamage() == 0)
            {
                block = "Not Blocking";
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
