using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    [SerializeField] private Transform _trackingPoint;

    private float _leftBorder = 0;
    private float _rightBorder = 36;
    private float _upBorder = 0;
    private float _downBorder = -2;
    private float _objectX;
    private float _objectY;
    private float _cameraX;
    private float _cameraY;

    private void Update()
    {
        transform.position = GetPosition();
    }

    private Vector3 GetPosition()
    {
        _objectX = _trackingPoint.position.x;
        _objectY = _trackingPoint.transform.position.y;

        if (_objectX > _leftBorder)
            if (_objectX < _rightBorder)
                _cameraX = _objectX;
            else _cameraX = _rightBorder;
        else _cameraX = _leftBorder;

        if (_objectY < _upBorder)
            if (_objectY > _downBorder)
                _cameraY = _objectY;
            else _cameraY = _downBorder;
        else _cameraY = _upBorder;

        return new Vector3(_cameraX, _cameraY, transform.position.z);
    }
}
