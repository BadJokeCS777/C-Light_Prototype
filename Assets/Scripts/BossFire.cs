using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    [SerializeField] private float _speed = 5;

    public int Damage { get; private set; } = 20;
    public Color Color { get; private set; } = Color.grey;

    private int _direction;

    private ParticleSystem _particleSystem;
    private Rigidbody2D _rigitbody;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _rigitbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();

        _renderer.color = Color;
        _particleSystem.startColor = Color;

        _direction = (int)transform.localScale.z;

        transform.rotation = new Quaternion(0, 0, 90 * _direction, 90);

        Destroy(gameObject, 3);
        _particleSystem.Play();
    }

    private void Update()
    {
        _rigitbody.velocity = new Vector2(_direction * _speed * Time.deltaTime * 100, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health player;

        if (collision.gameObject.TryGetComponent(out player))
            player.ApplyImpact(-Damage);

        Destroy(gameObject);
    }
}
