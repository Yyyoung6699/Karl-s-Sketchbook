using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintFrame : MonoBehaviour
{
    private float targetAngle = 0f;
    public float rotationAmount = 90f;
    private Interaction interaction;
    public float rotationSpeed = 2.0f; // 旋转速度
    public float currentAngle;
    public GameObject Star;
    public GameObject Light;
    public GameObject StarMask;
    private PaintFrame4 paintFrame4;
    void Start()
    {
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
        paintFrame4 = GameObject.Find("InteractionFrame4").GetComponent<PaintFrame4>();
    }

    void Update()
    {
        if (interaction.HitInteractionFrame == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                targetAngle += rotationAmount;
                StartCoroutine(RotateObject(targetAngle)); // 启动旋转协程
            }
        }
        if (interaction.StartStar == true)
        {
            StarMask.SetActive(false);
            currentAngle = transform.rotation.eulerAngles.z;
            if (Mathf.Approximately(currentAngle, 270f) && paintFrame4.rightAngle)
            {
                Star.SetActive(true);
                Light.SetActive(true);
            }
            else
            {
                Star.SetActive(false);
                Light.SetActive(false);
            }
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
