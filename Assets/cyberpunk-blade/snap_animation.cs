using UnityEngine;

public class snap_animation : MonoBehaviour
{
    [SerializeField] private Animator snap_animator;
    [SerializeField] private GameObject snap_target;
    [SerializeField] private bool openTrigger = false;
    [SerializeField] private string snapAnimationName = "snap_animations";

    private void OnTriggerEnter(Collider other)
    {
        if (snap_target != null && openTrigger && other.gameObject == snap_target)
        {
            if (openTrigger)
            {
                snap_animator.Play(snapAnimationName, 0, 0.0f);
                Debug.Log("Animation is triggered");
            }
        }
    }
}
