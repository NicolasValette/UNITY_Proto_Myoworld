using Myoworld.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Myoworld.Character
{
    public class CharacterInput : MonoBehaviour
    {
        [SerializeField]
        private bool _isDebugMode = false;
        [SerializeField]
        private GameObject _objectToMove;

        private IMove _moveProvider;

        // Start is called before the first frame update
        void Start()
        {
            _moveProvider = _objectToMove.GetComponentInChildren<IMove>();
            if ( _moveProvider == null)
            {
                Debug.LogError($"Move provider missing for objett : {gameObject.name}");
            }
        }

        public void OnMove(InputValue value)
        {
            Vector2 direction = value.Get<Vector2>();
            if (_isDebugMode) Debug.Log($"(OnMove) Input Value : {direction} ");
            _moveProvider.Move(direction);
        }
    }
}