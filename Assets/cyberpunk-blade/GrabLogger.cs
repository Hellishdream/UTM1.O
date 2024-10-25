using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLogger : MonoBehaviour
{
    [SerializeField] private Grabbable grabScript;

    private void Start()
    {
        if (grabScript == null)
        {
            Debug.LogError("Grab script reference is not set. Please assign a Grabbable script in the inspector.");
            return;
        }

        //  grabScript.WhenGrabbed += OnGrabbed;
    }
}
