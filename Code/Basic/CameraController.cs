using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;//��ȡ��ɫ
    private float mouseX, mouseY;//����ƶ���ֵ
    public float mouseSensitivity;//���������
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
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;//Input.GetAxis�Ǹ����������Ļ���ƶ�����һ��-1��1��ֵ
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        player.Rotate(Vector3.up * mouseX);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
