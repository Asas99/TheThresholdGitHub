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
        if (CanJump)
        {
            rb.linearVelocityY = JumpForce;
        }
    }

    public void Move(float direction)
    {
        //transform.position += new Vector3(MoveSpeed * Time.fixedDeltaTime * direction, 0, 0);
        rb.linearVelocityX = MoveSpeed * direction;
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
        if (collision.gameObject.CompareTag("zemin"))
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                if (collision.GetContact(i).normal.y > 0.5f)
                {
                    CanJump = true;
                    break;
                }
            }
        }
    }
    public void OnCollisionStay2D(Collision2D collision)
    //Düz olmayan bir terrain oyuna eklenirse collision checkini tek bir kere yaparsak karakterin zıplamasında sorun yaşanabilir bu yüzden collision stay de de kontrol yaparak karakterin zıplayabilmesi için ekledim
    //Şart değil çıkarılabilir ya da commentlenebilir
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                if (collision.GetContact(i).normal.y > 0.5f)
                {
                    CanJump = true;
                    break;
                }
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        CanJump = false;
    }
}
