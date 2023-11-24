using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float focalLength = 5.0f; // ����һ�������ʼֵ

    [SerializeField]
    private float previewYOffset = 0.06f;

    [SerializeField]
    public GameObject realObject;
    public GameObject previewObject;
    public GameObject previewInstantiate;
    public GameObject realInstance;

    public void StartShowingPlacementPreview(GameObject prefab, Vector3 BuildLoc)//Դ����public void StartShowingPlacementPreview(GameObject prefab, Vector2Int size)
    {
        previewInstantiate = Instantiate(prefab, BuildLoc, prefab.transform.rotation);
    }
    private void Instantiation(GameObject RealInstantiate, Vector3 BuildL, Quaternion Prerotation)
    {
        realInstance = Instantiate(RealInstantiate, BuildL, Prerotation);
        realInstance.name = "DoorTrigger";

        GameObject Door = GameObject.Find("Door");
        realInstance.transform.SetParent(Door.transform);
    }

    public void UpdatePosition(Vector3 position)//Դ����public void UpdatePosition(Vector3 position, bool validity)
    {
        if (previewInstantiate != null)
        {
            previewInstantiate.transform.position = new Vector3(position.x, position.y + previewYOffset, position.z);
        }
    }

    public void StopShowingPreview()
    {
        Destroy(previewInstantiate);
    }

    private void Update()
    {
        Camera PhoneCamera = GameObject.Find("PhoneCamera").GetComponent<Camera>();//��ȡ�ֻ����λ�����ڵõ�����λ��
        Transform PhoneCameraTransform = PhoneCamera.transform;

        float scroll = Input.GetAxis("Mouse ScrollWheel");//��������ֵ
        if (scroll != 0.0f)
        {
            // ���ݹ������������� focalLength
            focalLength += scroll;
            // ȷ�� focalLength ����С��һ����Сֵ������0��
            focalLength = Mathf.Max(focalLength, 0.0f);
            // �ڴ˴����Ը�����Ҫ������������
        }
        Vector3 BuildLoc = PhoneCameraTransform.position + PhoneCameraTransform.forward * focalLength;//��ý���λ��

        if (Input.GetKeyDown(KeyCode.J))
        {
            StartShowingPlacementPreview(previewObject, BuildLoc);
        }
        UpdatePosition(BuildLoc);

        if (Input.GetMouseButtonDown(0))
        {
            //realInstance = Instantiate(realObject, BuildLoc, previewInstantiate.transform.rotation);
            Instantiation(previewObject, BuildLoc, previewInstantiate.transform.rotation);
            StopShowingPreview();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Destroy(realInstance);
        }
    }

}
