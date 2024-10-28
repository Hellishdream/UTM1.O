using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLogger : MonoBehaviour
{
    private Grabbable grabScript;

    private void Start()
    {
        

        //  grabScript.WhenGrabbed += OnGrabbed;
    }

    private void Update()
    {
        if (grabScript == null)
        {
            Debug.LogError("Grab script reference is not set. Please assign a Grabbable script in the inspector.");
            return;
        }
    }
}
