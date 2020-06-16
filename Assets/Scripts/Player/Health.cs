using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _value = 150;
    private int _maxValue = 150;

    private void Start()
    {
        DontDestroyOnLoad(this);
        _text.text = _value.ToString();
    }

    public void ApplyImpact(int damage)
    {
        _value += damage;
        _text.text = _value.ToString();

        if (_value > _maxValue)
            _value = _maxValue;

        if (_value <= 0)
        {
            _value = 0;
            Destroy(gameObject);
        }
    }
}
