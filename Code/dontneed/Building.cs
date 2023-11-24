using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float focalLength = 5.0f; // 设置一个焦距初始值

    [SerializeField]
    private float previewYOffset = 0.06f;

    [SerializeField]
    public GameObject realObject;
    public GameObject previewObject;
    public GameObject previewInstantiate;
    public GameObject realInstance;

    public void StartShowingPlacementPreview(GameObject prefab, Vector3 BuildLoc)//源代码public void StartShowingPlacementPreview(GameObject prefab, Vector2Int size)
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

    public void UpdatePosition(Vector3 position)//源代码public void UpdatePosition(Vector3 position, bool validity)
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
        Camera PhoneCamera = GameObject.Find("PhoneCamera").GetComponent<Camera>();//获取手机相机位置用于得到建造位置
        Transform PhoneCameraTransform = PhoneCamera.transform;

        float scroll = Input.GetAxis("Mouse ScrollWheel");//鼠标滚轮数值
        if (scroll != 0.0f)
        {
            // 根据滚动方向来调整 focalLength
            focalLength += scroll;
            // 确保 focalLength 不会小于一个最小值（比如0）
            focalLength = Mathf.Max(focalLength, 0.0f);
            // 在此处可以根据需要进行其他操作
        }
        Vector3 BuildLoc = PhoneCameraTransform.position + PhoneCameraTransform.forward * focalLength;//获得建造位置

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
