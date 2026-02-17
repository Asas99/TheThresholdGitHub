using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour, IMovement, IJump
{
    public float MoveSpeed, JumpForce;
    public bool CanJump;
    public Rigidbody2D rb;
    public int Movementdirection;

    public void Jump()
    {
        rb.linearVelocityY = JumpForce;
    }

    public void Move(int direction)
    {
        transform.position += new Vector3(MoveSpeed * Time.fixedDeltaTime * direction, 0, 0);
    }

    public void SetDirection(int direction)
    {
        Movementdirection = direction;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move(Movementdirection);
    }
    // Update is called once per frame
    public void OnCollisionEnter2D(Collision2D collision)
    {
        CanJump = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        CanJump = false;
    }
}
