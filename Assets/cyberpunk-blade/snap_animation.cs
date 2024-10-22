using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap_animation : MonoBehaviour
{
    public Animator animator;
    public string animationTriggerName = "SnapAnimation";
    private SnapInteractor snapInteractor;

    private void Start()
    {
        // Get the SnapInteractor component
        snapInteractor = GetComponent<SnapInteractor>();

        // Subscribe to the WhenSelectingInteractable event
        snapInteractor.WhenSelectingInteractable += OnSnap;
    }

    private void OnSnap(SnapInteractable snapInteractable)
    {
        // Trigger the animation when snapping occurs
        animator.SetTrigger(animationTriggerName);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed
        if (snapInteractor != null)
        {
            snapInteractor.WhenSelectingInteractable -= OnSnap;
        }
    }
}