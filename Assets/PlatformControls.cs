using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformControls : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Rigidbody2D rb;

    public int CoinsCollected = 0;

    bool IsGrounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();
        Debug.Log(v);

        rb.linearVelocity = new Vector2(v.x * speed, rb.linearVelocity.y);
    }
    void OnJump()
    {
       if(IsGrounded)
       {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
       }
       
    }
    void OnTriggerEnter2D()
    {
        IsGrounded = true;
    }
    void OnTriggerExit2D()
    {
        IsGrounded = false;
    }


}
