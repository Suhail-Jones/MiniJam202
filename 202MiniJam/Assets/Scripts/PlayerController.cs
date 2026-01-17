using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float sprintSpeed;
    private Rigidbody2D rb;
    private float horizontalInput;
    private Animation anim;
    public String output = "";
    private Boolean facingRight = true;

    public GameObject spell;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Check horizontalInput to determine if a flip is needed
        if (horizontalInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && facingRight)
        {
            Flip();
        }

        checkAttack();
    }

    void FixedUpdate()
    {
        sprintSpeed = Input.GetKey(KeyCode.LeftShift) ? 1.75f : 1f;

        if (horizontalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed * sprintSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        
    }

    void checkAttack()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            //anim.Play("Jab");
            output = "Jab";
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
            GameObject spawnedSpell = Instantiate(spell, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), transform.rotation);
            spawnedSpell.transform.eulerAngles += new Vector3(0, 0, 90);
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

    // Function to flip the character's local scale
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1; // Invert the X-axis
        transform.localScale = currentScale;
    }
}
