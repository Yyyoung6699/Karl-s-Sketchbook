using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowZhangAi : MonoBehaviour
{
    public GameObject windowZhangAi;
    public Subtitle subtitle;
    private Interaction interaction;
    private PlayerController playerController;
    private CameraController cameraController;
    private UI ui;

    public bool StartMove = false;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        cameraController = GameObject.Find("PlayerCamera").GetComponent<CameraController>();
        subtitle = GameObject.Find("Canvas").GetComponent<Subtitle>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.StartWindow == true)
        {
            windowZhangAi.SetActive(false);
            subtitle.StartTutorial4 = true;
            if(StartMove == false)
            {
                StartCoroutine(Unlock());
                StartMove = true;
            }

            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                ui.Hide_UI_Movement();
            }
        }
    }

    public IEnumerator Unlock()
    {
        yield return new WaitForSeconds(8.0f);
        playerController.afterTutorial = true;
        cameraController.afterTutorial = true;
        yield return new WaitForSeconds(4.0f);
        ui.Show_UI_Movement();
    }
}
