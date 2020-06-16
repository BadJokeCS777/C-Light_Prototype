using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{

    [SerializeField] private BossFire _fireBall;

    private BossFire _FBClone;
    private Rigidbody2D _rigidbody;

    private float _upBorder = 4.5f;
    private float _downBorder = -3f;
    private float Speed = 7;
    private int _direction = 1;
    private int _damage = 50; 

    private float _timeFire = 0;
    private float _valueFire = 2f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Fire();
        Move();
    }

    private void Fire()
    {
        _timeFire += Time.deltaTime;
        if (_timeFire >= _valueFire)
        {
            _FBClone = Instantiate(_fireBall, new Vector3(transform.position.x, transform.position.y, 0),
                    transform.rotation);
            _FBClone.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
            
            _timeFire = 0;
        }
    }

    private void Move()
    {
        if (transform.position.y <= _downBorder)
            _direction = 1;
        if (transform.position.y >= _upBorder)
            _direction = -1;

        transform.position = new Vector3(transform.position.x, transform.position.y + Speed * _direction * Time.deltaTime, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health player;

        if (collision.gameObject.TryGetComponent(out player))
            player.ApplyImpact(-_damage);
    }
}
