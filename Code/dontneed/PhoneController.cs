using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public static bool hadPhone;

    void Update()
    {
        Camera playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        Transform playerCameraTransform = playerCamera.transform;

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (playerCamera != null)
            {
                transform.LookAt(playerCameraTransform);
                transform.localEulerAngles -= new Vector3(0, 0, 0);
                transform.SetParent(playerCameraTransform);

                transform.position = playerCameraTransform.position + playerCameraTransform.forward * 1.0f;
                hadPhone = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = playerCameraTransform.position - playerCameraTransform.forward * 1.0f;
            hadPhone = false;
        }
    }
}
