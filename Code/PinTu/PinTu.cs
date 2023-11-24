using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinTu : MonoBehaviour
{
    private Interaction interaction;
    public int PinTuZhuangTai;

    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public GameObject Image6;
    public GameObject Image7;
    public float transitionDuration = 1.0f;
    public GameObject Trigger;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
        PinTuZhuangTai = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.StartPinTu == true)
        {
            Image1.SetActive(true);
            Image2.SetActive(true);
            Image3.SetActive(true);
            Image4.SetActive(true);
            Image5.SetActive(true);
            Image6.SetActive(true);
        }

        if (interaction.HitInteractionFrame2 == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                PinTuZhuangTai = PinTuZhuangTai + 1;
            }
        }

        if (PinTuZhuangTai == 1) 
        {
            StartCoroutine(MoveImages(Image3.transform, new Vector3(0.26f, Image3.transform.localPosition.y, Image3.transform.localPosition.z)));
            StartCoroutine(MoveImages(Image5.transform, new Vector3(-0.13f, Image5.transform.localPosition.y, Image5.transform.localPosition.z)));
        }
        if (PinTuZhuangTai == 2)
        {
            StartCoroutine(MoveImages(Image4.transform, new Vector3(-0.26f, Image4.transform.localPosition.y, Image4.transform.localPosition.z)));
            StartCoroutine(MoveImages(Image6.transform, new Vector3(-0.13f, Image6.transform.localPosition.y, Image6.transform.localPosition.z)));
        }
        if (PinTuZhuangTai == 3)
        {
            StartCoroutine(RotateLocalYTo90Degrees(Image5.transform));
            StartCoroutine(RotateLocalYTo90Degrees(Image6.transform));
            Image7.SetActive(false);
        }
    }

    IEnumerator MoveImages(Transform imageTransform, Vector3 targetLocalPosition)
    {
        float elapsedTime = 0;

        Vector3 startingLocalPosition = imageTransform.localPosition;

        while (elapsedTime < transitionDuration)
        {
            imageTransform.localPosition = Vector3.Lerp(startingLocalPosition, targetLocalPosition, (elapsedTime / transitionDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageTransform.localPosition = targetLocalPosition;
    }

    IEnumerator RotateLocalYTo90Degrees(Transform targetTransform)
    {
        Quaternion startRotation = targetTransform.localRotation;
        Quaternion targetRotation = Quaternion.Euler(targetTransform.localRotation.eulerAngles.x, 170, targetTransform.localRotation.eulerAngles.z);
        float elapsedTime = 0;

        while (elapsedTime < transitionDuration)
        {
            targetTransform.localRotation = Quaternion.Lerp(startRotation, targetRotation, (elapsedTime / transitionDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        targetTransform.localRotation = targetRotation;
    }
}
