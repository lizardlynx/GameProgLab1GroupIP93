using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float screenHeight;
    private float screenWidth;
    public float speed = 20f;
    public float jumpSpeed = 5;
    private bool grounded = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(grounded);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {     
        var axis = Input.GetAxis("Horizontal");
        var velocity = rb.velocity;
        velocity.x = axis * speed;
        rb.velocity = velocity;

        if (grounded && (Input.GetKeyDown(KeyCode.Space)))
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = true;
            Debug.Log("Grounded");
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            grounded = false;
            Debug.Log("Not Grounded!");
        }
    }

}
