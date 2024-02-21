using Myoworld.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCapture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        float timeBeforeDestruction = 0;
        ICapture captureProvider = collision.gameObject.GetComponent<ICapture>();
        if (captureProvider != null)
        {
            captureProvider.Capture();
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            Renderer rend = gameObject.GetComponent<MeshRenderer>();
            rend.enabled = false;
            IPlayEffect effect = gameObject.GetComponent<IPlayEffect>();
            if (effect != null)
            {
                timeBeforeDestruction = effect.RunEffect();
            }
            Destroy(gameObject, timeBeforeDestruction);
            Debug.Log("Duration = " + timeBeforeDestruction);
        }
    }
}
