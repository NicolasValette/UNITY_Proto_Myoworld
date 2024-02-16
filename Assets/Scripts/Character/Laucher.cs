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
        private float _launchForce = 5f;
        #endregion


        public void Throw()
        {
            Debug.Log("Launch !!");
            GameObject ball = Instantiate<GameObject>(_objectToLaunchPrefab, _originePoint.position, _originePoint.rotation);
            var rg = ball.GetComponent<Rigidbody>();
            rg.AddForce(_originePoint.up * _launchForce, ForceMode.Impulse);
            rg.AddTorque(Random.insideUnitSphere * 10f);
        }

    }
}