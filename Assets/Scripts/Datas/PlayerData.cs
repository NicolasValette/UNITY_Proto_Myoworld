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

        public float Speed => _speed;
        public float Acceleration => _acceleration;
        public float RotationSpeed => _rotationSpeed;

    }
}
