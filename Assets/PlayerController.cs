using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private float movementX;
    private float movementY;
    [SerializeField] private float speed = 5f;
   
    void OnMove(InputValue Value)
    {
        Vector2 vec = Value.Get<Vector2>();

        Debug.Log(vec);
        movementX = vec.x;
        movementY = vec.y;
    }
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float XmoveDistance = movementX * speed * Time.fixedDeltaTime;
        float YmoveDistance = movementY * speed * Time.fixedDeltaTime;
        transform.position = new Vector2(transform.position.x + XmoveDistance, transform.position.y + YmoveDistance);
        
    }
}
