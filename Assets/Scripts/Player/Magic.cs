using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(FireBall))]
public class Magic : MonoBehaviour
{
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private FireBall _fireBall;
    [SerializeField] private TMP_Text _text;

    private FireBall _FBClone;
    private SpellType _spell = SpellType.Damage;

    private int _mana = 100;
    private int _maxMana = 100;
    private float _timeManaRegen = 5;
    private int _manaRestore = 10;
    private bool _isRestored = false;

    private void Start()
    {
        _text.text = _mana.ToString();
    }

    private void Update()
    {
        ChangeColor();
        Fire();
        //ManaRegeneration();
    }

    private void ChangeColor()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _spell = SpellType.Damage;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _spell = SpellType.Heal;
        }
    }

    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_mana >= 15)
            {
                ApplyImpact(-15);

                _FBClone = Instantiate(_fireBall, new Vector3(_shootingPoint.position.x, _shootingPoint.position.y, 0),
                    transform.rotation);
                _FBClone.transform.localScale = _shootingPoint.localScale;

                switch (_spell)
                {
                    case SpellType.Damage:
                        _FBClone.SetColor(Color.red);
                        break;
                    case SpellType.Heal:
                        _FBClone.SetColor(Color.green);
                        break;
                }

                _text.text = _mana.ToString();
            }
        }
    }

    public void ApplyImpact(int impact)
    {
        _mana += impact;

        if (_isRestored == false)
            StartCoroutine(ManaRegeneration());
    }

    private IEnumerator ManaRegeneration()
    {
        _isRestored = true;

        while (_mana < _maxMana)
        {
            yield return new WaitForSeconds(_timeManaRegen);

            _mana += _manaRestore;
            _mana = _mana >= _maxMana ? _maxMana : _maxMana;
            _text.text = _mana.ToString();

            if (_mana == _maxMana)
            {
                _isRestored = false;
                break;
            }
        }

        StopCoroutine(ManaRegeneration());
    }

    //private void ManaRegeneration()
    //{
    //    _timeManaRegen += Time.deltaTime;
    //    if (_timeManaRegen >= _valueManaRegen)
    //    {
    //        _timeManaRegen = 0;
    //        _mana += 5;

    //        if (_mana > _maxMana)
    //            _mana = _maxMana;

    //        _text.text = _mana.ToString();
    //    }
    //}
}

enum SpellType
{
    Damage, Heal
}