using Myoworld.Interfaces;
using UnityEngine;

namespace Myoworld.Character
{


    public class Laucher : MonoBehaviour, IThrow
    {
        #region Serialized Field
        [SerializeField]
        private GameObject _objectToLaunchPrefab;
        [SerializeField]
        private Transform _originePoint;
        [SerializeField]
        private Transform _player;
        [SerializeField]
        private float _launchForce = 5f;
        [SerializeField]
        private CharacterAnimation _animation;
        
        #endregion


        public void Throw()
        {
            Debug.Log("Launch !!");
            
            _animation.Throw();
        }
        public void Launch()
        {
            GameObject ball = Instantiate<GameObject>(_objectToLaunchPrefab, _originePoint.position, _originePoint.rotation);
            var rg = ball.GetComponent<Rigidbody>();
            rg.AddForce(_player.forward * _launchForce, ForceMode.Impulse);
            rg.AddTorque(Random.insideUnitSphere * 10f);
        }
      
    }
}