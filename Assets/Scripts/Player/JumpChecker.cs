using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpChecker : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private GameObject _jumpPoint;
    [SerializeField] private LayerMask _jumpPlace;

    public bool GroundCheck()
    {
        return Physics2D.OverlapCircle(_jumpPoint.transform.position, _radius, _jumpPlace);
    }
}
