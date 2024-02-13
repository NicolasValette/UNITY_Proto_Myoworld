using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myoworld.Character
{
    public class GroundCheck : MonoBehaviour
    {
        [SerializeField]
        private bool _isDebugMode;
        [SerializeField]
        private float _rayDistance;
        public bool IsGrounded()
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            RaycastHit hit;
            bool result = Physics.Raycast(ray, out hit, _rayDistance);

            if (_isDebugMode) Debug.Log($"Ground Check : {result}");
            return result;
        }

    }
}
