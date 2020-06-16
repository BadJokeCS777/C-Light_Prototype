using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] private float _leftBorder;
    [SerializeField] private float _rightBorder;
    [SerializeField] private GameObject _crystal;
    [SerializeField] private GameObject _potion;

    public float Speed = 5;
    
    private float _health = 10;
    private int _damage = 40;
    private int _direction = 1;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (transform.position.x <= _leftBorder)
            _direction = 1;
        if (transform.position.x >= _rightBorder)
            _direction = -1;

        transform.localScale = new Vector3(_direction, 1, 1);

        transform.localScale = new Vector3(_direction, 1, 1);
        _rigidbody.velocity = new Vector2(Speed * _direction * Time.deltaTime * 10, _rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        FireBall fireBall;
        Health player;

        if (collision.gameObject.TryGetComponent(out fireBall))
            if (fireBall.Color == Color.red)
                TakeDamage(fireBall.Damage);
            else
                TakeDamage(-fireBall.Damage);

        if (collision.gameObject.TryGetComponent(out player))
            player.ApplyImpact(-_damage);
    }

    private void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
            Instantiate(_crystal, transform.position, transform.rotation);
            Instantiate(_potion, transform.position, transform.rotation);
        }
    }
}
