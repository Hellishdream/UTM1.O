using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.UI.BodyUI;
using Meta.XR;

public class CustomHandMenu : HandMenu
{
    [SerializeField] private float gazeThreshold = 45f;
    [SerializeField] private float followSpeed = 5f;
    [SerializeField] private GameObject menuUIPrefab;

    private OVRHand leftHand;
    private bool isMenuVisible = false;

    protected  void OnEnable()
    {
        base.OnEnable();
        menuVisibleGazeDivergenceThreshold = gazeThreshold;
        SetupHand();
        SetupMenuUI();
    }

    private void SetupHand()
    {
        OVRCameraRig cameraRig = FindObjectOfType<OVRCameraRig>();
        if (cameraRig != null)
        {
            leftHand = cameraRig.leftHandAnchor.GetComponentInChildren<OVRHand>();
        }
    }

    private void SetupMenuUI()
    {
        if (menuUIPrefab != null)
        {
            GameObject menuInstance = Instantiate(menuUIPrefab, transform);
            menuInstance.transform.localPosition = Vector3.zero;
            menuInstance.transform.localRotation = Quaternion.identity;
        }
    }

    protected  void LateUpdate()
    {
        base.LateUpdate();
        UpdateMenuVisibility();
        UpdateMenuPosition();
    }

    private void UpdateMenuVisibility()
    {
        if (leftHand != null && leftHand.IsTracked)
        {
            Vector3 handDirection = leftHand.PointerPose.forward;
            Vector3 gazeDirection = Camera.main.transform.forward;

            float angle = Vector3.Angle(handDirection, gazeDirection);

            if (angle < gazeThreshold && !isMenuVisible)
            {
                ShowMenu();
            }
            else if (angle >= gazeThreshold && isMenuVisible)
            {
                HideMenu();
            }
        }
    }

    private void UpdateMenuPosition()
    {
        if (isMenuVisible && leftHand != null && leftHand.IsTracked)
        {
            Vector3 targetPosition = leftHand.PointerPose.position;
            Quaternion targetRotation = leftHand.PointerPose.rotation;

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * followSpeed);
        }
    }

    private void ShowMenu()
    {
        isMenuVisible = true;
        gameObject.SetActive(true);
    }

    private void HideMenu()
    {
        isMenuVisible = false;
        gameObject.SetActive(false);
    }
}
