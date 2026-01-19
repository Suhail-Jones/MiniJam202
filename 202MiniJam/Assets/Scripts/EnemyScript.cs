using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public bool isStunned = false;
    private SpriteRenderer spriteRenderer;
    private Animator anim;
    public GameObject spell;


    public GameObject hand;
    public GameObject zone1;
    public GameObject zone2;
    public GameObject zone3;
    public GameObject zone4;

    List<int> zoneOne = new List<int>();
    List<int> zoneTwo = new List<int>();
    List<int> zoneThree = new List<int>();
    List<int> zoneFour = new List<int>();

    System.Random random = new System.Random();

    private void Start()
    {
        //hand.GetComponent<DamagingObject>().setDamage(0);
        updateLists();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!isStunned)
        {
            chooseAttack();
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

    public void updateLists()
    {
        zoneOne.Add(0);
        zoneOne.Add(1);
        zoneOne.Add(2);
        zoneOne.Add(3);
        zoneOne.Add(4);

        zoneTwo.Add(0);
        zoneTwo.Add(1);
        zoneTwo.Add(2);
        zoneTwo.Add(3);

        zoneThree.Add(0);
        zoneThree.Add(1);
        zoneThree.Add(2);

        zoneFour.Add(0);
        zoneFour.Add(1);
    }
    public void block()
    {
        //Play block animation
    }

    public int checkZone()
    {
        int zoneInt;
        if (zone4.GetComponent<AlertEnemy>().playerInZone())
        {
            zoneInt = 4;
        }
        else if (zone3.GetComponent<AlertEnemy>().playerInZone())
        {
            zoneInt = 3;
        }
        else if (zone2.GetComponent<AlertEnemy>().playerInZone())
        {
            zoneInt = 2;
        }
        else if (zone1.GetComponent<AlertEnemy>().playerInZone())
        {
            zoneInt = 1;
        }
        else
        {
            zoneInt = 0;
        }
        return zoneInt;
    }

    public void chooseAttack()
    {
        int choice;
        if (checkZone() == 4)
        {
            choice = random.Next(zoneOne.Count);
            if (choice == 0)
            {
                hand.GetComponent<DamagingObject>().setDamage(1);
                anim.SetTrigger("jab");
                StartCoroutine(Freeze(1.5f));
            }
            else if (choice == 1)
            {
                //HeavyPunch
                Debug.Log("HeavyPunch");
            }
            else if (choice == 2)
            {
                GameObject spawnedSpell = Instantiate(spell, new Vector3(transform.position.x -2, transform.position.y, transform.position.z), transform.rotation);
                spawnedSpell.transform.eulerAngles += new Vector3(0, 0, 90);
                StartCoroutine(Freeze(1.5f));
            }
            else if (choice == 3)
            {
                doSuper();
                StartCoroutine(Freeze(3f));
            }
            else if(choice == 4)
            {
                //Nothing
                Debug.Log("Nothing");
            }
        }
        else if (checkZone() == 3)
        {
            choice = random.Next(zoneTwo.Count);
            if (choice == 0)
            {
                GameObject spawnedSpell = Instantiate(spell, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), transform.rotation);
                spawnedSpell.transform.eulerAngles += new Vector3(0, 0, 90);
                StartCoroutine(Freeze(1.5f));
            }
            else if (choice == 1)
            {
                //HeavyPunch
                Debug.Log("HeavyPunch");
            }
            else if (choice == 2)
            {
                doSuper();
                StartCoroutine(Freeze(3f));
            }
            else if (choice == 3)
            {
                //Nothing
                Debug.Log("Nothing");
            }
        }
        else if (checkZone() == 2)
        {
            choice = random.Next(zoneThree.Count);
            if (choice == 0)
            {
                Debug.Log("HeavyPunch");
            }
            else if (choice == 1)
            {
                doSuper();
                StartCoroutine(Freeze(3f));
            }
            else if (choice == 2)
            {
                //Nothing
                Debug.Log("Nothing");
            }
        }
        else if (checkZone() == 1)
        {
            choice = random.Next(zoneFour.Count);
            if (choice == 0)
            {
                doSuper();
                StartCoroutine(Freeze(3f));
            }
            else if (choice == 1)
            {
                //Nothing
                Debug.Log("Nothing");
            }
        }
    }

    public void doSuper()
    {
        GameObject spawnedSpell1 = Instantiate(spell, new Vector3(transform.position.x - 2, transform.position.y + 2, transform.position.z), transform.rotation);
        GameObject spawnedSpell2 = Instantiate(spell, new Vector3(transform.position.x - 2, transform.position.y + 1, transform.position.z), transform.rotation);
        GameObject spawnedSpell3 = Instantiate(spell, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), transform.rotation);
        spawnedSpell1.transform.eulerAngles += new Vector3(0, 0, 90);
        spawnedSpell2.transform.eulerAngles += new Vector3(0, 0, 90);
        spawnedSpell3.transform.eulerAngles += new Vector3(0, 0, 90);
    }
}
