using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;//获取角色
    private float mouseX, mouseY;//鼠标移动的值
    public float mouseSensitivity;//鼠标灵敏度
    public float xRotation;
    public bool afterTutorial = false;
    private void Update()
    {
        if (afterTutorial)
        {
            StartControl();
        }
    }

    public void StartControl()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;//Input.GetAxis是根据鼠标在屏幕中移动返回一个-1到1的值
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
