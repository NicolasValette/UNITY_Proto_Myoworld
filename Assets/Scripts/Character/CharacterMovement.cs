using Myoworld.Datas;
using Myoworld.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, IMove, IRotateCamera
{
    [SerializeField]
    private bool _isDebugMode = false;
    [SerializeField]
    private PlayerData _playerData;
    [SerializeField]
    private Rigidbody _rigidbody;
    [SerializeField]
    private GameObject _camera;

    private Vector2 _moveDirection = Vector2.zero;
    private Vector2 _cameraDelta = Vector2.zero;



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
        RotateCameraCharacter();
    }

    private void MoveCharacter ()
    {
        Vector3 direction = new Vector3(_moveDirection.x, 0, _moveDirection.y) * _playerData.Speed;
        direction.y = _rigidbody.position.y;
        
        Vector3 currentVelocity = Vector3.zero;
        //if (_isDebugMode) Debug.Log($"Move forward : {direction}");
        //_rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, direction, ref currentVelocity, _playerData.Acceleration);
        _rigidbody.transform.Translate(_moveDirection.x * _playerData.Speed * Time.deltaTime, 0f, _moveDirection.y * _playerData.Speed * Time.deltaTime);
    }
    private void RotateCameraCharacter()
    {

        //_camera.transform.Rotate(Vector3.up * _cameraDelta.x * Time.deltaTime * _playerData.RotationSpeed);
        Vector3 rotation = _camera.transform.localEulerAngles;
        rotation.y += _cameraDelta.x * Time.deltaTime * _playerData.RotationSpeed;
        rotation.z += _cameraDelta.y * Time.deltaTime * _playerData.RotationSpeed;
        rotation.z = Mathf.Clamp(rotation.z, 40f, 125f);
        _camera.transform.rotation = Quaternion.Euler(rotation);
        
        //_camera.transform.rotation.y = Mathf.Clamp(_camera.transform.rotation.y, -20f, 20f);
    }
    public void Move(Vector2 moveDirection)
    {
        _moveDirection = moveDirection;
       
    }
    public void RotateCamera(Vector2 cameraDirection)
    {
        _cameraDelta = cameraDirection;
    }
}
