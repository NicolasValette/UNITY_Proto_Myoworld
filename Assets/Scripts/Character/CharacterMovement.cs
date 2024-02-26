using Myoworld.Character;
using Myoworld.Datas;
using Myoworld.Interfaces;
using UnityEditor;
using UnityEngine;

namespace Myoworld.Character
{
    public class CharacterMovement : MonoBehaviour, IMove, IRotateCamera, IJump
    {
        #region Serialized Fields
        [SerializeField]
        private bool _isDebugMode = false;
        [SerializeField]
        private PlayerData _playerData;
        [SerializeField]
        private Rigidbody _rigidbody;
        [SerializeField]
        private GameObject _camera;
        [SerializeField]
        private CharacterAnimation _animator;
        #endregion

        private Vector2 _moveDirection = Vector2.zero;
        private Vector2 _cameraDelta = Vector2.zero;
        private GroundCheck _groundCheck;

        private float _jumpingTime = 0f;
        private bool _isJumping = false;
        private bool _isJumpActive = false;
        private float _fallingMultiplier = 1f;


        // Start is called before the first frame update
        void Start()
        {
            if (_rigidbody == null)
            {
                Debug.LogWarning($"RigidBody missing in {gameObject.name}");
                _rigidbody = gameObject.AddComponent<Rigidbody>();
            }

            _groundCheck = gameObject.GetComponentInChildren<GroundCheck>();
            if (_groundCheck == null)
            {
                Debug.LogError($"GroundCheck missing in {gameObject.name}");
            }
        }

        // Update is called once per frame
        void Update()
        {
            MoveCharacter();
            RotateCameraCharacter();
            JumpCharacter();
        }

        private void MoveCharacter()
        {
            Vector3 direction = new Vector3(_moveDirection.x, 0, _moveDirection.y) * _playerData.Speed;
            float speed = direction.sqrMagnitude;
            direction.y = _rigidbody.position.y;

            Vector3 currentVelocity = Vector3.zero;
            //if (_isDebugMode) Debug.Log($"Move forward : {direction}");
            //_rigidbody.velocity = Vector3.SmoothDamp(_rigidbody.velocity, direction, ref currentVelocity, _playerData.Acceleration);
            _rigidbody.transform.Translate(_moveDirection.x * _playerData.Speed * Time.deltaTime, 0f, _moveDirection.y * _playerData.Speed * Time.deltaTime);

      
            _animator.Move(speed);

        }
        private void RotateCameraCharacter()
        {
            Vector3 rotationCamera = _camera.transform.localEulerAngles;
            Vector3 rotationCharacter = _rigidbody.transform.localEulerAngles;
            rotationCharacter.y += _cameraDelta.x * Time.deltaTime * _playerData.RotationSpeed;
            rotationCamera.z += _cameraDelta.y * Time.deltaTime * _playerData.RotationSpeed;
            rotationCamera.z = Mathf.Clamp(rotationCamera.z, 75f, 125f);

            //Apply rotations
            _rigidbody.transform.rotation = Quaternion.Euler(rotationCharacter);
            var rot = Quaternion.Euler(rotationCamera);
            _camera.transform.localRotation = rot;
        }
        private void JumpCharacter()
        {
            //TODO : change this mechanics asap
            if (_isJumping)
            {
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _playerData.JumpForce, _rigidbody.velocity.z);
                _jumpingTime += Time.deltaTime;
            }

            if (_rigidbody.velocity.y >= 0)
            {
                _rigidbody.AddForce((_playerData.GravityScale) * _rigidbody.mass * _fallingMultiplier * Physics.gravity);
            }
            else if (_rigidbody.velocity.y < 0)
            {
                _rigidbody.AddForce((_playerData.FallingGravityScale) * _rigidbody.mass * _fallingMultiplier * Physics.gravity);
            }
            if (_jumpingTime > _playerData.JumpButtonTime)
            {
                _isJumping = false;
            }

            _animator.Jump();
        }

        public void Move(Vector2 moveDirection)
        {
            _moveDirection = moveDirection;

        }
        public void RotateCamera(Vector2 cameraDirection)
        {
            _cameraDelta = cameraDirection;
        }

        public void Jump()
        {

            if (!_isJumpActive && _groundCheck.IsGrounded())
            {
                _isJumping = true;
                _isJumpActive = true;
                _jumpingTime = 0f;
            }
            else
            {
                _isJumping = false; ;
                _isJumpActive = false;
            }

        }

    }
}
