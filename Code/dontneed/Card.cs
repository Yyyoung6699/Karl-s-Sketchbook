using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public static bool hadCard;
    public float scroll;//鼠标滚轮数值
    public float focalLength = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Camera playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        Transform playerCameraTransform = playerCamera.transform;

        //float scroll = Input.GetAxis("Mouse ScrollWheel");
        //if (scroll != 0.0f)
        //{
        //    // 根据滚动方向来调整 focalLength
        //    focalLength += scroll;
        //    // 确保 focalLength 不会小于一个最小值（比如0）
        //    focalLength = Mathf.Max(focalLength, 0.0f);
        //    // 在此处可以根据需要进行其他操作
        //}

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            if (playerCamera != null)
            {
                transform.LookAt(playerCameraTransform);
                transform.localEulerAngles = new Vector3(90, 180, 0);
                transform.SetParent(playerCameraTransform);

  
                transform.position = playerCameraTransform.position + playerCameraTransform.forward * focalLength;
                hadCard = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.localEulerAngles = new Vector3(60, 180, 30);
            Vector3 firstPos = playerCameraTransform.position + playerCameraTransform.forward * 4.0f;
            Vector3 leftOffset = -gameObject.transform.right * 2.0f;
            transform.position = firstPos - leftOffset + gameObject.transform.forward * 3.0f;
            hadCard = false;
        }
    }
}
