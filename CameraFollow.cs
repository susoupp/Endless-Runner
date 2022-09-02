using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _targetTransform;
    [SerializeField, Range(0.0f, 0.5f)] float _followSpeed;
    Vector3 _targetOffset;
    Vector3 _initialTargetPosition;
    void Start()
    {
        _initialTargetPosition = _targetTransform.position;
        _targetOffset = transform.position - _targetTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
       LerpToTargetOffset();
    }
    private void LerpToTargetOffset()
    {
        var targetPosition = new Vector3(_targetTransform.position.x,
                                         _initialTargetPosition.y,
                                         _targetTransform.position.z) + _targetOffset;
        transform.position = Vector3.Lerp(transform.position, targetPosition,_followSpeed);
    }
}
