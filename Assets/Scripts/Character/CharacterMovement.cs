using Myoworld.Datas;
using Myoworld.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, IMove
{
    [SerializeField]
    private bool _isDebugMode = false;
    [SerializeField]
    private PlayerData _playerData;
    [SerializeField]
    private Rigidbody _rigidbody;

    private Vector2 _moveDirection = Vector2.zero;

    
    // Start is called before the first frame update
    void Start()
    {
        if (_rigidbody == null)
        {
            Debug.LogWarning($"RigidBody missing in {gameObject.name}");
            _rigidbody = gameObject.AddComponent<Rigidbody>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    private void MoveCharacter ()
    {
        Vector3 direction = new Vector3(_moveDirection.x, 0, _moveDirection.y) * _playerData.Speed;
        direction.y = _rigidbody.position.y;
        
        Vector3 currentVelocity = Vector3.zero;
        if (_isDebugMode) Debug.Log($"Move forward : {direction}");
        //_rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, direction, ref currentVelocity, _playerData.Acceleration);
        _rigidbody.transform.Translate(_moveDirection.x * _playerData.Speed * Time.deltaTime, 0f, _moveDirection.y * _playerData.Speed * Time.deltaTime);
    }
    public void Move(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
       
    }
}
