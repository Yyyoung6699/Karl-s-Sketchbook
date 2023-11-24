using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private float MaxUseDistance = 5f;
    [SerializeField]
    private LayerMask UseLayers;

    public void OpenDoor(RaycastHit hit)
    {
        hit.collider.TryGetComponent<Door>(out Door door);
        if (door != null && door.CanOpen == true)
        {
            UI.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                door.playAnimation();
                UI.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (Camera != null)
        {
            Ray ray = new Ray(Camera.position, Camera.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, MaxUseDistance))
            {
                // 如果射线击中了某个物体
                if (hit.collider.gameObject.name == "Door")
                {
                    OpenDoor(hit);
                }
                else
                {
                    UI.SetActive(false);
                }
            }

        }
    }

}

