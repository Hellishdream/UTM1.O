using UnityEngine;
using UnityEngine.XR;

public class HandVisibilityController : MonoBehaviour
{
    public GameObject handMenuUI; // Assign your UI GameObject in the inspector
    private OVRHand ovrHand;

    void Start()
    {
        ovrHand = GetComponent<OVRHand>();
    }

    void Update()
    {
        if (ovrHand.IsTracked && ovrHand.HandConfidence == OVRHand.TrackingConfidence.High)
        {
            // Check if the palm is visible
            if (ovrHand.GetFingerIsPinching(OVRHand.HandFinger.Index))
            {
                ShowUI();
            }
            else
            {
                HideUI();
            }
        }
        else
        {
            HideUI();
        }
    }

    void ShowUI()
    {
        if (!handMenuUI.activeSelf)
        {
            handMenuUI.SetActive(true);
        }
    }

    void HideUI()
    {
        if (handMenuUI.activeSelf)
        {
            handMenuUI.SetActive(false);
        }
    }
}
