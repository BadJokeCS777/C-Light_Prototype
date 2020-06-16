using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JumpChecker))]
public class PlayerMove : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private float _leftBorder = -8.8f;
    private float _rightBorder = 44;
    private float _upBorder = 4.5f;
    private float _downBorder = -7;
    private float _objectX;
    private float _objectY;

    private JumpChecker _jumpChecker;
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private int _direction;

    private void Start()
    {
        DontDestroyOnLoad(this);
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _jumpChecker = GetComponent<JumpChecker>();
    }

    private void Update()
    {
        Move();
        Jump();
        CheckBorder();
    }

    private void Move()
    {
        _direction = (int)Input.GetAxisRaw("Horizontal");

        if (_direction == 0)
        {
            _animator.SetBool("IsWalk", false);
        }
        else
        {
            _animator.SetBool("IsWalk", true);
            transform.localScale = new Vector3(_direction, 1, 1);
            transform.position = new Vector3(transform.position.x + Speed * _direction * Time.deltaTime,
                transform.position.y, transform.position.z);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if(_jumpChecker.GroundCheck())
                _rigidbody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
    }

    private void CheckBorder()
    {
        if (transform.position.x > _leftBorder)
            if (transform.position.x < _rightBorder)
                _objectX = transform.position.x;
            else 
                _objectX = _rightBorder;
        else 
            _objectX = _leftBorder;

        if (transform.position.y > _downBorder)
            if (transform.position.y < _upBorder)
                _objectY = transform.position.y;
            else 
                _objectY = _upBorder;
        else
            _objectY = _downBorder;

        transform.position = new Vector3(_objectX, _objectY, transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Zombie zombie;

        if (collision.gameObject.TryGetComponent(out zombie))
        {
            _direction = (int)zombie.transform.localScale.x;
            _rigidbody.AddForce(new Vector2(2 * _direction, 3), ForceMode2D.Impulse);
        }
    }
}
