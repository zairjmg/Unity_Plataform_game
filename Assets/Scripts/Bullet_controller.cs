using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private Vector3 _ditection;

    private Rigidbody2D _rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        _rigidbody.velocity = _ditection * speed;
    }


    public void SetDirection(Vector2 direction) {
        _ditection = direction;
    }

    public void DestroyBullet() {
        Destroy(gameObject);
    }
}
