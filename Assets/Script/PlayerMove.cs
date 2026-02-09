using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool onGrounded;

    public Animator theAnim;

    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        theAnim = GetComponent<Animator>();
    }

    void Update()
    {

        onGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if(Input.GetKeyDown(KeyCode.Space) && onGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce ,0f);
        }

        if(Input.GetAxisRaw("Horizontal") > 0f)
        {
            rb.velocity = new Vector3(movSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector3(-movSpeed, rb.velocity.y, 0f);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0f);
        }

        theAnim.SetFloat("movSpeed", Mathf.Abs(rb.velocity.x));
        theAnim.SetBool("onGrounded", onGrounded);
    }
}