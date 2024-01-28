using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float runSpeedMultiplier = 1.5f;
    public float jumpForce = 10f;
    public float bendAngle = 45f;
    public Transform groundCheckPoint;
    public LayerMask groundLayer;
    public Transform firePoint;
    public Bullet bulletPrefab;
    public Animator anim;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isFacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float moveSpeed = speed * horizontalInput * (Input.GetKey(KeyCode.LeftShift) ? runSpeedMultiplier : 1f);
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if (horizontalInput != 0f && isGrounded)
        {
            anim.SetBool("isWalking", true);
            Invoke("ChangeBoolWalk", 1f);
        }
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            anim.SetBool("isRunning", true);
            Invoke("ChangeBoolRun", 1f);
        }

        float verticalInput = Input.GetAxis("Vertical");

        // Zıplama
        if (isGrounded && (Input.GetButtonDown("Jump") || verticalInput > 0))
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("isJumping", true);
            Invoke("ChangeBoolJump", 1f);
        }

        // Eğilme
        if (verticalInput < 0)
        {
            anim.SetBool("isBending", true);
            Invoke("ChangeBoolBend", 1f);
        }

        // Ateş Etme
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            anim.SetBool("isAttacking", true);
            Invoke("ChangeBoolAttack", 1f);

        }

        // Karakter Yönü
        if (horizontalInput > 0 && !isFacingRight || horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    public void ChangeBoolJump()
    {
        anim.SetBool("isJumping", false);
    }
    public void ChangeBoolAttack()
    {
        anim.SetBool("isAttacking", false);
    }
    public void ChangeBoolWalk()
    {
        anim.SetBool("isWalking", false);
    }
    public void ChangeBoolBend()
    {
        anim.SetBool("isBending", false);
    }
    public void ChangeBoolRun()
    {
        anim.SetBool("isRunning", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void Attack()
    {
        Bullet bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.rbody.AddForce(new Vector2(100f, bullet.rbody.velocity.y));
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
