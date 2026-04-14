using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformControls : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float jumpForce2;
    private int doubleJump;
    private Rigidbody2D rb;

    public int CoinsCollected = 0;

    private bool IsGrounded;
    private bool IsFacingRight = true;


    private Animator playerAnim;
    private SpriteRenderer playerSpriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        playerAnim.SetBool("IsRunning", rb.linearVelocity.x != 0);
        playerAnim.SetBool("IsGrounded", IsGrounded);
    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        Debug.Log(v);

        rb.linearVelocity = new Vector2(v.x * speed, rb.linearVelocity.y);
        if((v.x < 0) && IsFacingRight)
        {
            playerSpriteRenderer.flipX = true;
            IsFacingRight = false;
        }
        if((v.x > 0) && IsFacingRight == false)
        {
            playerSpriteRenderer.flipX = false;
            IsFacingRight = true;
        }
    }
    void OnJump()
    {
       if(IsGrounded)
       {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
       } 
       else if(doubleJump == 1)
        {
            rb.AddForce(new Vector2(0, jumpForce2), ForceMode2D.Impulse);
            doubleJump = doubleJump - 1;
        }

       
    }
    void OnTriggerEnter2D()
    {

        IsGrounded = true;
        if(doubleJump == 0)
        {
            doubleJump = doubleJump + 1;
        }
    }
    void OnTriggerExit2D()
    {
        IsGrounded = false;
    }


}
