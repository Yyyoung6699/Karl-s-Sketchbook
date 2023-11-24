using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using com.guinealion.animatedBook;

public class BookController : MonoBehaviour
{
    //public Camera playerCameraNew;
    public static bool hadBook;
    private LightweightBookHelper BookHelper;//获取书本控制脚本
    private UI ui;
    private Subtitle subtitle;
    private HospitalBook hospitalBook;

    public GameObject VolumeGameOver;
    public GameObject BookObject;//书本的模型
    public Texture[] textureArray;//书内容

    public bool Over2 = false;
    public bool CanChange = false;
    public bool CanPreview;
    public int CurrentTextrue;

    public string arImage;
    private string previousArImage = "null";

    public bool afterTutorial = false;
    void Start()
    {
        BookHelper = GetComponent<LightweightBookHelper>();//获取书本控制脚本
        ui = GameObject.Find("Canvas").GetComponent<UI>();
        subtitle = GameObject.Find("Canvas").GetComponent<Subtitle>();
        hospitalBook = GameObject.Find("HospitalBook").GetComponent<HospitalBook>();
        //ui.Show_UI_NoBook();
        CurrentTextrue = 0;
    }

    void Update()
    {
        if (afterTutorial)
        {
            arImage = DefaultObserverEventHandler.ArImage;
            if (Input.GetKey(KeyCode.X))
            {
                ui.Show_UI_HaveBook();
                ui.Hide_UI_NoBook();
                ui.Hide_UI_Preview();
                TakeBook();
                NoPreview();
                CanPreview = true;
            }

            if (Input.GetKey(KeyCode.C))
            {
                NoPreview();
                BookHelper.Close();
                StartCoroutine(DelayedBackBook());
            }

            if (Input.GetMouseButtonDown(1) && CanPreview == true)
            {
                ui.Show_UI_Preview();
                ui.Hide_UI_HaveBook();
                Preview();
                CanChange = true;
                CanPreview = false;
            }

            if (arImage != null)
            {
                ArChange();
            }

            if (Input.GetKey(KeyCode.F) && hospitalBook.Over == true)
            {
                StartCoroutine(GameOver());
                subtitle.StartTutorial8 = true;
                Over2 = true;
            }
            if (Over2 == true)
            {
                StartCoroutine(ChangeVolume());
            }
            //if (hospitalBook.Over == true)
            //{
            //    TakeBook();
            //    if(Over2 == false)
            //    {
            //        StartCoroutine(GameOver());
            //        Over2 = true;
            //    }
            //}
        }
        else
        {
            if (Input.GetKey(KeyCode.X))
            {
                ui.Hide_UI_NoBook();
                Tutorial();
                subtitle.StartTutorial2 = true;
            }
            arImage = DefaultObserverEventHandler.ArImage;
            if (arImage != null)
            {
                ArChange();
            }
        }
    }

    public IEnumerator GameOver()
    { 
        ChangeContent(18, 18);
        Renderer renderer = BookObject.GetComponent<Renderer>();
        if (renderer.material.HasProperty("_Columns"))
        {
            renderer.material.SetFloat("_Columns", 2.0f); // 设置Alpha属性值为0.5
        }
        if (renderer.material.HasProperty("_Rows"))
        {
            renderer.material.SetFloat("_Rows", 5.0f); // 设置Alpha属性值为0.5
        }
        if (renderer.material.HasProperty("_Progress"))
        {
            renderer.material.SetFloat("_Progress", 0.0f); // 设置Alpha属性值为0.5
        }
        BookHelper.GameOver();

        TakeBook();

        yield return new WaitForSeconds(2.0f);
        for (int i = 0; i < 7; i++)
        {
            BookHelper.NextPage();
            yield return new WaitForSeconds(0.5f); // 等待1秒钟
        }
        BookHelper.NextPage();
        yield return new WaitForSeconds(8.0f);
        BookHelper.Close();
        StartCoroutine(DelayedBackBook());
    }

    void Tutorial()
    {
        StartCoroutine(TutorialDelay());
    }
    public IEnumerator TutorialDelay()
    {
        //yield return new WaitForSeconds(4.0f);
        Camera playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        Transform playerCameraTransform = playerCamera.transform;
        transform.LookAt(playerCameraTransform);
        //transform.localEulerAngles -= new Vector3(0, 0, 0);
        transform.SetParent(playerCameraTransform);
        transform.position = playerCameraTransform.position + playerCameraTransform.forward * 2.0f;
        BookHelper.Open();
        yield return new WaitForSeconds(6.0f);
        ChangeContent(11, 11); 
        for (int i = 0; i < 2; i++)
        {
            BookHelper.NextPage();
            yield return new WaitForSeconds(1.0f); // 等待1秒钟
        }
        BookHelper.NextPage();
        StartCoroutine(DelayedChangeContent(10, 10));
    }

    void TakeBook()
    {
        Camera playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        Transform playerCameraTransform = playerCamera.transform;
        if (playerCamera != null)
        {
            transform.LookAt(playerCameraTransform);
            //transform.localEulerAngles -= new Vector3(0, 0, 0);
            transform.SetParent(playerCameraTransform);

            transform.position = playerCameraTransform.position + playerCameraTransform.forward * 2.0f;
            hadBook = true;
        }
        BookHelper.Open();
    }

    IEnumerator DelayedBackBook()//延迟1秒
    {
        yield return new WaitForSeconds(0.6f);
        BackBook();
    }
    void BackBook()
    {
        Camera playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
        Transform playerCameraTransform = playerCamera.transform;
        transform.position = playerCameraTransform.position - playerCameraTransform.forward * 1.0f;
        hadBook = false;
        //ui.Show_UI_NoBook();
        ui.Hide_UI_HaveBook();
        ui.Hide_UI_Preview();
    }

    public void UsePaperNoContent()//解密正确后，画消失
    {
        StartCoroutine(PaperNoContent());
    }
    public IEnumerator PaperNoContent()
    {
        Renderer renderer = BookObject.GetComponent<Renderer>();
        Material material = renderer.material;
        float duration = 1.0f;

        if (material.HasProperty("_ContentAlpha"))
        {
            float startAlpha = material.GetFloat("_ContentAlpha");
            float targetAlpha = 0.0f;
            float currentTime = 0.0f;

            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                float t = currentTime / duration;
                material.SetFloat("_ContentAlpha", Mathf.Lerp(startAlpha, targetAlpha, t));
                yield return null;
            }

            material.SetFloat("_ContentAlpha", targetAlpha);
        }
        NoPreview();
        BookHelper.Close();
        yield return new WaitForSeconds(0.8f);//解密后close书的时间
        BackBook();
        ResetContent();
    }
    public void PaperHaveContent()
    {
        Renderer renderer = BookObject.GetComponent<Renderer>();
        Material material = renderer.material;
        material.SetFloat("_ContentAlpha", 1.0f);
    }
    public void ResetContent()//解密后，回到初始页面
    {
        CurrentTextrue = 0;
        ChangeContent(0, 0);
    }

    IEnumerator DelayedChangeContent(int y, int n)//延迟1秒为了和动画契合，修改书的画
    {
        yield return new WaitForSeconds(0.15f);
        ChangeContent(y, n);
    }
    public void ChangeContent(int y, int n)//修改书的画
    {
        Renderer renderer = BookObject.GetComponent<Renderer>();
        Material material = renderer.material;

        if (material.HasProperty("_PaperContent"))
        {
            material.SetTexture("_PaperContent", textureArray[y]);
        }
        if (material.HasProperty("_PaperNoContent"))
        {
            material.SetTexture("_PaperNoContent", textureArray[n]);
        }
    }
        //public void ChangeMaterial()
        //{
        //    Renderer renderer = BookObject.GetComponent<Renderer>();
        //    // 获取当前的材质
        //    Material material = renderer.material;

        //    // 检查是否有名为"Paper Content"的属性
        //    if (material.HasProperty("_PaperContent"))
        //    {
        //        // 设置"_PaperContent"属性为textureArray[1]
        //        material.SetTexture("_PaperContent", textureArray[1]);
        //    }
        //    else
        //    {
        //        Debug.LogWarning("Material does not have a property named '_PaperContent'");
        //    }
        //}

        void Preview()
    {
        Renderer renderer = BookObject.GetComponent<Renderer>();
        renderer.material.renderQueue = 3000; // 设置Render Queue值为3000

        if (renderer.material.HasProperty("_Alpha"))
        {
            renderer.material.SetFloat("_Alpha", 0.4f); // 设置Alpha属性值为0.5
        }
        UseMoveObject();
    }

    void NoPreview()
    {
        Renderer renderer = BookObject.GetComponent<Renderer>();
        renderer.material.renderQueue = 2000; // 设置Render Queue值为3000

        if (renderer.material.HasProperty("_Alpha"))
        {
            renderer.material.SetFloat("_Alpha", 1.0f); // 设置Alpha属性值为0.5
        }
    }

    public void UseMoveObject()
    {
        StartCoroutine(MoveObject());
    }
    public IEnumerator MoveObject()
    {
            Camera playerCamera = GameObject.Find("PlayerCamera").GetComponent<Camera>();
            Transform playerCameraTransform = playerCamera.transform;

            Vector3 targetPosition = transform.position - playerCameraTransform.forward * 0.5f
                                                    - playerCameraTransform.right * 0.6f
                                                    - playerCameraTransform.up * 0.4f;

            float elapsedTime = 0;
            float moveDuration = 0.2f;
            Vector3 startingPosition = transform.position;

            while (elapsedTime < moveDuration)
            {
                transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / moveDuration));
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPosition; // 确保在结束时达到准确位置
    }

    public IEnumerator ChangeVolume()//滤镜
    {
        yield return new WaitForSeconds(13.5f);
        Volume volume = VolumeGameOver.GetComponent<Volume>();
        ColorAdjustments colorAdjustments;
        if (volume.profile.TryGet(out colorAdjustments))
        {
            float targetValue = -10.0f;  // 目标值
            float transitionSpeed = 0.5f;  // 过渡速度，根据需要调整
            colorAdjustments.postExposure.Override(Mathf.Lerp(colorAdjustments.postExposure.value, targetValue, Time.deltaTime * transitionSpeed));
        }
    }

    public void ArChange()
    {
        if (arImage != previousArImage) // 只有在 ArImage 发生变化时才执行
        {
            previousArImage = arImage; // 更新上一帧的 ArImage
            if (arImage == "AR1")
            {
                BookHelper.NextPage();
                StartCoroutine(DelayedChangeContent(1, 2));
                CurrentTextrue = 1;
                PaperHaveContent();
            }
            else if (arImage == "AR2")
            {
                BookHelper.NextPage();
                StartCoroutine(DelayedChangeContent(3, 4));
                CurrentTextrue = 2;
                PaperHaveContent();
            }
            else if (arImage == "AR3")
            {
                BookHelper.NextPage();
                StartCoroutine(DelayedChangeContent(5, 6));
                CurrentTextrue = 3;
                PaperHaveContent();
            }
            else if (arImage == "AR4")
            {
                BookHelper.NextPage();
                StartCoroutine(DelayedChangeContent(7, 8));
                CurrentTextrue = 4;
                PaperHaveContent();
            }
            else if (arImage == "AR5")
            {
                BookHelper.NextPage();
                StartCoroutine(DelayedChangeContent(12, 13));
                CurrentTextrue = 5;
                PaperHaveContent();
                afterTutorial = true;
                ui.Show_UI_HaveBook();
                ui.Hide_UI_NoBook();
                ui.Hide_UI_Preview();
                CanPreview = true;
                subtitle.StartTutorial3 = true;
            }
            else if (arImage == "AR6")
            {
                BookHelper.NextPage();
                StartCoroutine(DelayedChangeContent(14, 15));
                CurrentTextrue = 6;
                PaperHaveContent();
            }
            else if (arImage == "AR7")
            {
                BookHelper.NextPage();
                StartCoroutine(DelayedChangeContent(16, 17));
                CurrentTextrue = 7;
                PaperHaveContent();
            }
            else if (arImage == "AR10")
            {
                BookHelper.NextPage();
                StartCoroutine(DelayedChangeContent(19, 20));
                CurrentTextrue = 8;
                PaperHaveContent();
            }
        }       
    }
}
