using UnityEngine;
using System.Collections;

public class HandMenuController : MonoBehaviour
{
    public GameObject handMenuUI; // Assign your UI prefab here in the inspector
    private bool isMenuVisible = false;
    private OVRHand leftHand; // Assuming you are using Oculus Integration
    private bool handMenuToggleAllowed = true; // To prevent rapid toggling

    void Start()
    {
        // Attempt to get the OVRHand component from the left hand anchor
        GameObject leftHandAnchor = GameObject.Find("LeftHandAnchor");
        if (leftHandAnchor != null)
        {
            leftHand = leftHandAnchor.GetComponent<OVRHand>();
        }

        if (leftHand == null)
        {
            Debug.LogError("OVRHand component not found on LeftHandAnchor");
        }
    }

    void Update()
    {
        if (leftHand == null)
        {
            return; // Exit early if leftHand is not set
        }

        // Check if all fingers are extended and the palm is facing forward
        if (AreAllFingersExtended() && IsPalmFacingForward() && handMenuToggleAllowed)
        {
            ToggleMenuVisibility();
            StartCoroutine(HandMenuCooldown());
        }
    }

    private bool AreAllFingersExtended()
    {
        // Check if all fingers are extended using pinch strength values
        return leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Thumb) > 0.9f &&
               leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > 0.9f &&
               leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Middle) > 0.9f &&
               leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Ring) > 0.9f &&
               leftHand.GetFingerPinchStrength(OVRHand.HandFinger.Pinky) > 0.9f;
    }

    private bool IsPalmFacingForward()
    {
        // Assuming that the forward vector of the palm is aligned with the negative Z-axis of the hand transform
        Vector3 palmForward = -leftHand.transform.forward;
        return Vector3.Dot(palmForward, Vector3.forward) > 0.7f; // Adjust the threshold based on your needs
    }

    private void ToggleMenuVisibility()
    {
        isMenuVisible = !isMenuVisible;
        handMenuUI.SetActive(isMenuVisible);
    }

    private IEnumerator HandMenuCooldown()
    {
        handMenuToggleAllowed = false;
        yield return new WaitForSeconds(1.0f); // Adjust the cooldown duration as needed
        handMenuToggleAllowed = true;
    }
}
