using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCardScript : MonoBehaviour
{
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private GameObject UI;

    public GameObject Card;
    //public GameObject Player;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Camera != null)
        {
            

            Ray ray = new Ray(Camera.position, Camera.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 5.0f))
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //Vector3 PointOffset = hit.point + hit.normal * 1.0f;
                    //Quaternion rotation = Quaternion.LookRotation(PointOffset);
                    GameObject decal = Instantiate(Card, hit.point, Quaternion.identity);
                    decal.transform.forward = -hit.normal;
                    GameObject Door = GameObject.Find("Door");
                    decal.transform.SetParent(Door.transform);
                }

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
}
