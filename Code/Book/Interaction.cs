using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Transform Camera;
    public float MaxDistance = 100.0f;
    public float InteractionDistance = 10.0f;
    public float DetectDistance = 100.0f;
    public int textrue;
    public GameObject Decal_1;

    public bool HitDetectObj = false;
    public bool HitInteractionDoor = false;
    public bool HitInteractionBook = false;
    public bool HitInteractionFrame = false;
    public bool HitInteractionFrame2 = false;
    public bool HitInteractionFrame4 = false;
    public bool StartDoor;
    public bool StartRainbow;
    public bool StartHuaban;
    public bool StartWindow;
    public bool StartStar;
    public bool StartPinTu;
    public bool StartCave;
    public int StartTiaoSePan = 0;

    private UI ui;
    private BookController bookController;
    // Start is called before the first frame update
    void Start()
    {
        StartDoor = false;
        StartRainbow = false;
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        bookController = GameObject.Find("Book_Necromancer").GetComponent<BookController>();
    }

    void Update()
    {
        Ray ray = new Ray(Camera.position, Camera.forward);
        RaycastHit hit;

        ShootRay(ray, out hit);
        FInteraction(ray, out hit);
        Derect(ray, out hit);
    }

    void ShootRay(Ray ray, out RaycastHit hit)
    {
        hit = new RaycastHit(); // 初始化 hit 变量

        if (Physics.Raycast(ray, out hit, MaxDistance))
        {
            BookController bookController = GameObject.Find("Book_Necromancer").GetComponent<BookController>();
            textrue = bookController.CurrentTextrue;
            //if (hit.collider.gameObject != null)
            //{
            //    Debug.Log(MaxDistance, hit.collider.gameObject);
            //}
            //else
            //{
            //    Debug.Log("没集中");
            //}
            if (hit.collider.gameObject.name == "Door" || hit.collider.gameObject.name == "RainbowTrigger" || hit.collider.gameObject.name == "Huaban" || hit.collider.gameObject.name == "TiaoSePan" || hit.collider.gameObject.name == "InteractionFrame" || hit.collider.gameObject.name == "InteractionFrame2" || hit.collider.gameObject.name == "Cave Trriger")
            {
                ui.Show_UI_Point();
            }
            else
            {
                ui.Hide_UI_Point();
            }
            if (Input.GetMouseButtonDown(0) && bookController.CanChange == true)
            {
                if (hit.collider.gameObject.name == "Door" && textrue == 1)
                {
                    bookController.UsePaperNoContent();
                    StartDoor = true;
                }
                if (hit.collider.gameObject.name == "RainbowTrigger" && textrue == 2)
                {
                    bookController.UsePaperNoContent();
                    StartRainbow = true;
                }
                if (hit.collider.gameObject.name == "Huaban" && textrue == 3)
                {
                    bookController.UsePaperNoContent();
                    StartHuaban = true;
                }
                if (hit.collider.gameObject.name == "TiaoSePan" && textrue != 0)
                {
                    bookController.UsePaperNoContent();
                    StartTiaoSePan = textrue;
                }
                if (hit.collider.gameObject.name == "WindowZhangAi" && textrue == 5)
                {
                    bookController.UsePaperNoContent();
                    StartWindow = true;
                }
                if (hit.collider.gameObject.name == "InteractionFrame" && textrue == 6)
                {
                    bookController.UsePaperNoContent();
                    StartStar = true;
                }
                if (hit.collider.gameObject.name == "InteractionFrame2" && textrue == 7)
                {
                    bookController.UsePaperNoContent();
                    StartPinTu = true;
                }
                if (hit.collider.gameObject.name == "Cave Trriger" && textrue == 8)
                {
                    bookController.UsePaperNoContent();
                    StartCave = true;
                }
            }
        }
    }

    void FInteraction(Ray ray, out RaycastHit hit)
    {
        hit = new RaycastHit(); // 初始化 hit 变量

        if (Physics.Raycast(ray, out hit, InteractionDistance))
        {
            if (hit.collider.gameObject.name == "GrayKnob")
            {
                HitInteractionDoor = true;
                ui.Show_UI_Interact();
            }
            else
            {
                HitInteractionDoor = false;
            }

            if (hit.collider.gameObject.name == "HospitalBook" && bookController.Over2 == false)
            {
                HitInteractionBook = true;
                ui.Show_UI_Interact();
            }
            else
            {
                HitInteractionBook = false;
            }

            if (hit.collider.gameObject.name == "InteractionFrame")
            {
                HitInteractionFrame = true;
                ui.Show_UI_Interact();
            }
            else
            {
                HitInteractionFrame = false;
            }

            if (hit.collider.gameObject.name == "InteractionFrame2" && StartPinTu == true)
            {
                HitInteractionFrame2 = true;
                ui.Show_UI_Interact();
            }
            else
            {
                HitInteractionFrame2 = false;
            }

            if (hit.collider.gameObject.name == "InteractionFrame4")
            {
                HitInteractionFrame4 = true;
                ui.Show_UI_Interact();
            }
            else
            {
                HitInteractionFrame4 = false;
            }

            if (hit.collider.gameObject.name != "GrayKnob" && hit.collider.gameObject.name != "HospitalBook" && hit.collider.gameObject.name != "InteractionFrame" && hit.collider.gameObject.name != "InteractionFrame2" && hit.collider.gameObject.name != "InteractionFrame4")
            {
                ui.Hide_UI_Interact();
            }
            if (bookController.Over2 == true)
            {
                ui.Hide_UI_Interact();
            }
        }
    }


    void Derect(Ray ray, out RaycastHit hit)
    {
        hit = new RaycastHit(); // 初始化 hit 变量

        if (Physics.Raycast(ray, out hit, DetectDistance))
        {
            if (hit.collider.gameObject.name == "PaintTest")
            {
                HitDetectObj = true;
            }
            else
            {
                HitDetectObj = false;
            }
        }
    }
}
