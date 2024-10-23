
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snap_animation : MonoBehaviour
{
    [SerializeField] private Animator snap_animator;
    [SerializeField] private GameObject snap_target;
    [SerializeField] private bool openTrigger = false;

    private const string SNAP_ANIMATION_NAME = "snap_animations";
    private void OnTriggerEnter(Collider other)
    {
        if (snap_target != null && openTrigger && other.gameObject == snap_target)
        {
            if (openTrigger)
            {
                snap_animator.Play(SNAP_ANIMATION_NAME, 0, 0.0f);
                Debug.Log("Animation is triggered");

            }

        }


    }
}