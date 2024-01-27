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
    public GameObject bulletPrefab;
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
        // Yürüme ve Koşma
        float horizontalInput = Input.GetAxis("Horizontal");
        float moveSpeed = speed * horizontalInput * (Input.GetKey(KeyCode.LeftShift) ? runSpeedMultiplier : 1f);
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        if (horizontalInput != 0f)
        {
            anim.SetBool("isWalking", true);
        }
        if (moveSpeed != 0f)
        {
            anim.SetBool("isRunning", true);
        }

        // Zemin Kontrolü (Raycast kullanarak)
        isGrounded = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, 0.1f, groundLayer);
        float verticalInput = Input.GetAxis("Vertical");

        // Zıplama
        if (isGrounded && (Input.GetButtonDown("Jump") || verticalInput > 0))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("isJumping", true);
        }

        // Eğilme
        if (verticalInput < 0)
        {
            anim.SetBool("isBending", true);

        }

        // Ateş Etme
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
            //anim.SetBool("isAttacking", true);

        }

        // Karakter Yönü
        if (horizontalInput > 0 && !isFacingRight || horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    void Attack()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
