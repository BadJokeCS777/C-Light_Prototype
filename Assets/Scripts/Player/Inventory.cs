using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    [SerializeField] private TMP_Text _potionCount;
    [SerializeField] private TMP_Text _crystalCount;
    [SerializeField] private GameObject _panel;

    [SerializeField] private Health _health;
    [SerializeField] private Magic _magic;

    private int _crystals = 0;
    private int _potions = 0;


    private void Start()
    {
        DontDestroyOnLoad(this);
        _potionCount.text = _potions.ToString();
        _crystalCount.text = _crystals.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12)
        {
            _crystals++;
            _crystalCount.text = _crystals.ToString();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == 13)
        {
            _potions++;
            _potionCount.text = _potions.ToString();
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
            if(_potions > 0)
            {
                _potions--;
                _potionCount.text = _potions.ToString();
                _health.ApplyImpact(50);
            }

        if (Input.GetKeyDown(KeyCode.X))
            if (_crystals > 0)
            {
                _crystals--;
                _crystalCount.text = _crystals.ToString();
                _magic.ApplyImpact(50);
            }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            _panel.SetActive(true);
        }
    }
}
