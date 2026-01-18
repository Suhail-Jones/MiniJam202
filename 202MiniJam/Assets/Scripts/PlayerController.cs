using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float sprintSpeed;
    private Rigidbody2D rb;
    private float horizontalInput;
    private Animator anim;
    public string output = "";
    private SpriteRenderer spriteRenderer;
    public bool isStunned = false;

    // Added variables for flipping

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Check horizontalInput to determine if a flip is needed
        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        if(isStunned == false)
        {
            checkAttack();
        }
    }

    void FixedUpdate()
    {
        if (isStunned == false)
        {
            sprintSpeed = Input.GetKey(KeyCode.LeftShift) ? 1.75f : 1f;

            if (horizontalInput != 0)
            {
                rb.velocity = new Vector2(horizontalInput * moveSpeed * sprintSpeed, rb.velocity.y);
                anim.SetBool("isWalking", true);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("isWalking", false);
        }
    }

    void checkAttack()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            anim.SetTrigger("jab");
            output = "Jab";
            StartCoroutine(PerformAttack(0.5f));

        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            //anim.Play("HeavyPunch");
            output = "HeavyPunch";
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            //anim.Play("Spell");
            output = "Spell";
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            //anim.Play("Ultimate");
            output = "Ultimate";
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            //anim.Play("Block");
            output = "Block";
        }
    }
    IEnumerator PerformAttack(float attackStunDuration)
    {
        // Set stunned state
        isStunned = true;

        // Wait for the stun duration
        yield return new WaitForSeconds(attackStunDuration);

        // End stun
        isStunned = false;
    }
}
