using UnityEngine;

namespace Myoworld.Character
{
    public class CharacterAnimation : MonoBehaviour
    {
        #region Serialized Fields
        [SerializeField]
        private Animator _animator;
        #endregion
        private void SetParameter(string parameterName)
        {
            _animator.SetTrigger(parameterName);
        }
        private void SetParameter(string parameterName, float value)
        {
            _animator.SetFloat(parameterName, value);
        }

        public void Move (float speed)
        {
           SetParameter("Speed", speed);
        }
        public void Wave()
        {
            SetParameter("Waving");
        }
        public void Throw()
        {
            SetParameter("Throw");
        }
        public void Victory ()
        {
            SetParameter("Victory");
        }
        public void Jump()
        {
            SetParameter("Jump");
        }
        
    }
}
