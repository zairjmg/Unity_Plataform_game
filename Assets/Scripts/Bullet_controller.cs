using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;

    private Vector3 _ditection;

    public AudioClip _audio;
    private Rigidbody2D _rigidbody;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(_audio);
    }

    private void FixedUpdate() {
        _rigidbody.velocity = _ditection * speed;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        player_move _player = other.GetComponent<player_move>();
        Enemy _enemy = other.GetComponent<Enemy>();

        if (_player != null) {
            _player.Hit();
            DestroyBullet();
        }
        if (_enemy != null) {
            _enemy.Hit();
            DestroyBullet();
        }
        
    }

    /* private void OnCollisionEnter2D(Collision2D other) {
        player_move _player = other.collider.GetComponent<player_move>();
        Enemy _enemy = other.collider.GetComponent<Enemy>();

        if (_player != null) _player.Hit();
        if (_enemy != null) _enemy.Hit();

        DestroyBullet();
    } */

    public void SetDirection(Vector2 direction) {
        _ditection = direction;
    }

    public void DestroyBullet() {
        Destroy(gameObject);
    }
}
