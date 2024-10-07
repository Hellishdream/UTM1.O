using UnityEngine;

public class GazeInteraction : MonoBehaviour
{
    public Transform cameraTransform; // Assign the main camera or HMD's transform

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit))
        {
            if (hit.transform == transform) // Check if the gaze is on this object
            {
                // Implement what happens when the user gazes at the menu
                Debug.Log("Gaze is on the menu");
            }
        }
    }
}
