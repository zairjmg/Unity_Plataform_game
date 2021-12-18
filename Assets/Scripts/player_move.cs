using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    public float Speed;
    public float jumpForce;

    private Rigidbody2D _rigidbody;
    private float h;
    private bool _grounded;

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
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.green);

        if (Physics2D.Raycast(transform.position, Vector2.down, 0.1f))
        {
            _grounded = true;
        }
        else 
        {
            _grounded = false;
        }

        /* Saltar */
        if (Input.GetKeyDown(KeyCode.W) && _grounded == true)
        {
            Jump();
        }
    }

    private void Jump() {
        _rigidbody.AddForce(Vector2.up * jumpForce);
    }

    private void FixedUpdate()
    {
        //Debug.Log(Grounded);
        _rigidbody.velocity = new Vector2(h * Speed, _rigidbody.velocity.y);
    }
}
