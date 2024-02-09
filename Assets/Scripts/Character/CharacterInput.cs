using Myoworld.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Myoworld.Character
{
    public class CharacterInput : MonoBehaviour
    {
        #region SERIALIZED FIELDS
        [SerializeField]
        private bool _isDebugMode = false;
        [SerializeField]
        private GameObject _objectToMove;
        [SerializeField]
        private GameObject _camera;
        #endregion
        private IMove _moveProvider;
        private IRotateCamera _cameraRotatorProvider;

        // Start is called before the first frame update
        void Start()
        {
            _moveProvider = _objectToMove.GetComponentInChildren<IMove>();
            if ( _moveProvider == null)
            {
                Debug.LogError($"Move provider missing for objett : {gameObject.name}");
            }

            _cameraRotatorProvider = _camera.GetComponentInChildren<IRotateCamera>();
            if (_cameraRotatorProvider == null)
            {
                Debug.LogError($"Camera Rotator Provider provider missing for objett : {gameObject.name}");
            }
        }

        #region EVENT METHOD
        public void OnMove(InputValue value)
        {
            Vector2 direction = value.Get<Vector2>();
           // if (_isDebugMode) Debug.Log($"(OnMove) Input Value : {direction} ");
            _moveProvider.Move(direction);
        }
        public void OnLook(InputValue value)
        {
            Vector2 direction = value.Get<Vector2>();
            Debug.Log("OnLook, direction : " + direction);
            _cameraRotatorProvider.RotateCamera(direction);
        }
        #endregion

    }
}