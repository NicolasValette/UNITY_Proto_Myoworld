using Myoworld.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myoworld.Character
{
    public class CharacterAnimationEvent : MonoBehaviour
    {
        [SerializeField]
        private GameObject _launcherGameObject;

        private IThrow _launcherProvider;

        private void Start()
        {
            _launcherGameObject.GetComponent<IThrow>();
        }
        public void ThrowEvent()
        {
            _launcherGameObject.GetComponent<IThrow>().Launch();
        }
    }
}