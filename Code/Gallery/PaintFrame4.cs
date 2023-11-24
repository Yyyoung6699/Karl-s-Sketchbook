using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintFrame4 : MonoBehaviour
{
    private float targetAngle = 0f;
    public float rotationAmount = 90f;
    private Interaction interaction;
    public float rotationSpeed = 2.0f; // 旋转速度
    public float currentAngle;
    public bool rightAngle = false;
    void Start()
    {
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
    }

    void Update()
    {
        if (interaction.HitInteractionFrame4 == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                targetAngle += rotationAmount;
                StartCoroutine(RotateObject(targetAngle)); // 启动旋转协程
            }
        }

        currentAngle = transform.rotation.eulerAngles.z;
        if (Mathf.Approximately(currentAngle, 180f))
        {
            rightAngle = true;
        }
        else
        {
            rightAngle = false;
        }
    }

    IEnumerator RotateObject(float targetAngle)
    {
        float startAngle = transform.rotation.eulerAngles.z;
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime * rotationSpeed;
            float angle = Mathf.LerpAngle(startAngle, targetAngle, t);
            transform.rotation = Quaternion.Euler(0, -60, angle);
            yield return null;
        }

        // 确保最终角度准确
        transform.rotation = Quaternion.Euler(0, -60, targetAngle);
    }
}
