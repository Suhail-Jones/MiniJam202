using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public float sprintSpeed;
    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftShift))
        {
            sprintSpeed = 1.75f;
        }
        else
        {
            sprintSpeed = 1f;
        }

        if (horizontalInput != 0)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed * sprintSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
