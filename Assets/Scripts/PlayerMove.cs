using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Velocidad
    public float Speed = 5f;
    //Rigidbody
    private Rigidbody2D rb;

    private Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * Speed * Time.fixedDeltaTime);
    }
}
