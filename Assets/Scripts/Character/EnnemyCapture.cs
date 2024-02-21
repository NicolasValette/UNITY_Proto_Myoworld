using Myoworld.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myoworld.Character
{
    public class EnnemyCapture : MonoBehaviour, ICapture
    {
        public static event Action OnCapture;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void Capture()
        {
            Debug.Log("Capture");
            OnCapture?.Invoke();
        }
    }
}