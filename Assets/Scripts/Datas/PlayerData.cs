using System.IO;
using UnityEngine;

namespace Myoworld.Datas
{
    [CreateAssetMenu(menuName = "Data/New Player")]
    public class PlayerData : ScriptableObject
    {
        [Header("Statistics")]
        [SerializeField]
        private float _speed = 5f;
        [SerializeField]
        private float _rotationSpeed = 5f;
        [SerializeField]
        private float _acceleration = 0.5f;


        [Header("Jump")]
        [Range(0f, 10f)]
        [SerializeField]
        private float _jumpForce = 5f;
        [Range(0f, 1f)]
        [SerializeField]
        private float _gravityScale = 0.15f;               //Change gravitiy of player to make him less floaty;
        [Range(0f, 1f)]
        [SerializeField]
        private float _fallingGravityScale = 0.7f;
        [SerializeField]
        private float _jumpButtonTime = 0.25f;
        [SerializeField]
        private float _jumpCooldown = 0.2f;



        public float Speed => _speed;
        public float Acceleration => _acceleration;
        public float RotationSpeed => _rotationSpeed;
  
        public float JumpForce => _jumpForce;
        public float GravityScale => _gravityScale;
        public float FallingGravityScale => _fallingGravityScale;
        public float JumpButtonTime => _jumpButtonTime;

    }
}
