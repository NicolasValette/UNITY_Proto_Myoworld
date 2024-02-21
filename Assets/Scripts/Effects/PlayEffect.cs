using Myoworld.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEffect : MonoBehaviour, IPlayEffect
{
    #region Serialized Fields
    [SerializeField]
    private ParticleSystem _particuleSystem;
    #endregion


    public float RunEffect()
    {
        _particuleSystem.Play();
        return _particuleSystem.main.duration;
    }
}
