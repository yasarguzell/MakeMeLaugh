using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] public Vector3 moveSpeed = new Vector3(0.02f, 0.0f, 0.0f);
    [SerializeField] public Vector3 jumpSpeed = new Vector3(0.0f, 1200f, 0.0f);
    [SerializeField] public GameObject[] Prefabs;
    [SerializeField] public float bulletspeed = 10f;
    public GameObject bulletInst;
    Rigidbody2D rb;
    public bool facingRight;
    public bool IsGrounded = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(moveSpeed);
            if (facingRight)
            {
                facingRight = false;
                Flip();
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(moveSpeed);
            if (!facingRight)
            {
                facingRight = true;
                Flip();
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(jumpSpeed);
            IsGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (facingRight)
            {
                var bulletInst = Instantiate(Prefabs[0], transform.position + new Vector3(-.01f, 0, 0), Quaternion.identity);
                bulletInst.GetComponent<Rigidbody2D>().velocity = new Vector2(-bulletspeed, 0f);
            }
            else
            {
                var bulletInst = Instantiate(Prefabs[0], transform.position + new Vector3(.01f, 0, 0), Quaternion.identity);
                bulletInst.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletspeed, 0f);
            }


        }

    }
    void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = true;
        }
    }

}
