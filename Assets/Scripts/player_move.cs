using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float Speed;
    public float jumpForce;

    private Rigidbody2D rb2d;
    private float h;
    private bool Grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        Debug.Log(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            Grounded = true;
        } 
        else Grounded = false;

        if(Input.GetKeyDown(KeyCode.W) && Grounded) {
            Jump();
        }
    }

    private void Jump() {
        rb2d.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(h, rb2d.velocity.y);
    }
}
