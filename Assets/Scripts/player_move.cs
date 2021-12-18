using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    /* Salto */
    public float jumpForce;

    /* Movimiento */
    public float Speed;
    private float h;
    private bool _grounded;

    /* parametro */
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* movimiento */
        h = Input.GetAxisRaw("Horizontal");
        Debug.Log("h: " + h);

        /* Detectar suelo */
        _grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        /* Saltar */
        if (Input.GetKeyDown(KeyCode.W) && _grounded == true)
        {
            Jump();
        }
    }

    private void Jump() {
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        //Debug.Log(Grounded);
        _rigidbody.velocity = new Vector2(h * Speed, _rigidbody.velocity.y);
    }
}
