using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_move : MonoBehaviour
{
    /* Prefap */
    public GameObject _bullet;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    /* Salto */
    public float jumpForce;

    /* Movimiento */
    public float Speed;
    private float h;
    private bool _grounded;
    private bool _facingRight = true;

    /* parametro */
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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

        /* Girar sprite */
        if (h < 0.0f && _facingRight == true)
        {
            flip();
        } 
        else if (h > 0.0f && _facingRight == false)
        {
            flip();
        }

        /* Detectar suelo */
        _grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        /* Saltar */
        if (Input.GetButtonDown("Jump") && _grounded == true)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(h * Speed, _rigidbody.velocity.y);
    }

    private void LateUpdate() {
        _animator.SetBool("Running", h != 0.0f);
        _animator.SetInteger("Idle", ((int)h));
        _animator.SetBool("Grounded", _grounded);
    }

    private void Jump() {
        _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void Shoot() {
        Vector3 direction;
        if (_facingRight == true)
        {
            direction = Vector2.right;
        } else
        {
            direction = Vector2.left;
        }

        GameObject bullet = Instantiate(_bullet, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullt_controller>().SetDirection(direction);
    }

    private void flip() {
        _facingRight = !_facingRight;
        float _localScaleX = transform.localScale.x;
        _localScaleX = _localScaleX * -1f;
        transform.localScale = new Vector3(_localScaleX, transform.localScale.y, transform.localScale.z);
    }
}
