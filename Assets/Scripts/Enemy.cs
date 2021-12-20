using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject _player;
    public GameObject _bullet;
    public GameObject _shootPoint;

    private float LastShoot;

    private int Health = 3;

    public int x;

    // Update is called once per frame
    void Update()
    {
        if (_player == null) return;

        Vector3 _direction = _player.transform.position - transform.position;
        if (_direction.x >= 0.0f) transform.localScale = new Vector3(1f, 1f, 1f);
        else transform.localScale = new Vector3(-1f, 1f, 1f);

        float distance = Mathf.Abs(_player.transform.position.x - _shootPoint.transform.position.x);

        if (distance < x && Time.time > LastShoot + 0.5f)
        {
            Shoot();
            LastShoot = Time.time;
        }
    }

    private void Shoot() {
        Vector3 direction;   
        if (transform.localScale.x == 1f) direction = Vector2.right;
        else direction = Vector2.left;

        GameObject bullet = Instantiate(_bullet, _shootPoint.transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<Bullet_controller>().SetDirection(direction);
    }

    public void Hit() {
        Health = Health - 1;
        if (Health == 0) Destroy(gameObject);
    }
}
