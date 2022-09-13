using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    UnityEvent JumpCompleted;

    [SerializeField]
    KeyboardInputSource _inputSource;

    [SerializeField]
    Rigidbody _rigidbody;

    bool _isJumping = false;

    [SerializeField]
    float _jumpForce;

    [SerializeField, Range(0f, 1f)]
    float _horizontalSpeed;
    private Vector3 _previousPosition;
    Vector3 _targetPosition;

    void FixedUpdate()
    {
        ProcessMovement();
    }
    
    private void ProcessMovement()
    {
         CheckIfLanded();
        if (_inputSource.Active && !_isJumping)
            Jump();

        if (_isJumping)
            ContinueJump();
    }

    private void ContinueJump()
    {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.z);
        Vector2 targetPosition = new Vector2 (_targetPosition.x, _targetPosition.z);

        Vector2 newPosition = Vector2.Lerp(currentPosition, targetPosition, _horizontalSpeed);

        _rigidbody.position = new Vector3(newPosition.x, _rigidbody.position.y, newPosition.y);
    }
    private void CheckIfLanded()
    {
        if(_rigidbody.velocity.magnitude < 0.001f)
            _isJumping = false; 


        if (JumpCompleted !=null)
            JumpCompleted.Invoke();
    }

    private void Jump()
    {
        _previousPosition = transform.position;
        
        _targetPosition = transform.position + (Vector3)_inputSource.Input * Constants.Module;

        _rigidbody.AddForce(Vector3.up * _jumpForce);

        _isJumping=true;
    }
    
    public void OnObstacleHit()
    {
        _targetPosition = _previousPosition;
    }
}
