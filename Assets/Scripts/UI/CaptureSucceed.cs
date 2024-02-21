using Myoworld.Character;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class CaptureSucceed : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _captureText;
    public void OnEnable()
    {
        EnnemyCapture.OnCapture += DisplayMessage;
    }
    public void OnDisable()
    {
        EnnemyCapture.OnCapture -= DisplayMessage;
    }
    public void Start()
    {
        _captureText.enabled = false;
    }
    public void DisplayMessage()
    {
        Debug.Log("1");
        StartCoroutine(DisplayCaptureMessage());
    }
    public IEnumerator DisplayCaptureMessage ()
    {
        Debug.Log("2");
        _captureText.enabled = true;
        yield return new WaitForSeconds(2f);
        _captureText.enabled = false;
        Debug.Log("3");
    }
}
