using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
//using Highlighters;

public class Rainbow : MonoBehaviour
{
    private Interaction interaction;
    public GameObject Rain;
    public GameObject rainbow;
    public GameObject globalVolume;

    public float alpha = 0.0f;
    public float ziFaGuang = 0.0f;

    private Door door;
    //private Highlighter highlighter;
    //private float OutlineNum = 0.0f;
    //private bool increasing = true; // ����׷�ٹ��ɷ���
    void Start()
    {
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
        door = GameObject.Find("Door").GetComponent<Door>();
        
        //if (!highlighter)
        //{
        //    highlighter = GetComponent<Highlighter>();
        //}//������ʾ����ʱȥ��
    }

    void Update()
    {
        if (interaction.StartRainbow == true) 
        {
            StopRain();
            ShowRainbow();
            RainbowAlpha();
        }
    }

    public void StopRain()
    {
        var visualEffect = Rain.GetComponent<VisualEffect>();
        visualEffect.Stop();//ֹͣ����
        door.Raining = false;
        ChangeVolume();//��������
    }

    public void ShowRainbow()
    {
        StartCoroutine(DelayShowRainbow());
    }
    IEnumerator DelayShowRainbow()
    {
        yield return new WaitForSeconds(2.0f);
        rainbow.SetActive(true);
        //Outline();
    }

    public void RainbowAlpha()
    {
        StartCoroutine(DelayRainbowAlpha());
    }
    IEnumerator DelayRainbowAlpha()
    {
        yield return new WaitForSeconds(2.0f);
        //GameObject Rainbow = GameObject.Find("Rainbow");
        if (rainbow != null )
        {
            Renderer renderer = rainbow.GetComponent<Renderer>();
            Material material = renderer.material;

            // ��ÿһ֡����͸����
            alpha = Mathf.Lerp(alpha, 1.0f, Time.deltaTime * 0.5f); // �⽫ʹ͸���ȴ�0�𽥹��ɵ�1
            if (renderer.material.HasProperty("_TransparentSrength"))
            {
                renderer.material.SetFloat("_TransparentSrength", alpha); // ����Alpha����ֵΪ0.5
            }
            ziFaGuang = Mathf.Lerp(alpha, 0.5f, Time.deltaTime * 0.5f);
            if (renderer.material.HasProperty("_EmissiveStrength"))
            {
                renderer.material.SetFloat("_EmissiveStrength", ziFaGuang); // ����Alpha����ֵΪ0.5
            }
            //// �����µ�͸���ȵ�����
            //Color color = material.color;
            //color.a = alpha;
            //material.color = color;
        }
    }

    //public void Outline()////������ʾ����ʱȥ��
    //{
    //    if (increasing)
    //    {
    //        OutlineNum = Mathf.Lerp(OutlineNum, 40.0f, Time.deltaTime * 8.0f); // �⽫ʹ͸���ȴ�0�𽥹��ɵ�40
    //        if (OutlineNum >= 39.9f)
    //        {
    //            increasing = false; // ����40��ı䷽��
    //        }
    //    }
    //    else
    //    {
    //        OutlineNum = Mathf.Lerp(OutlineNum, 0.0f, Time.deltaTime * 8.0f); // �⽫ʹ͸���ȴ�40�𽥹��ɻ�0
    //    }
    //    highlighter.Settings.BlurIterations = OutlineNum;
    //}

    public void ChangeVolume()//�����˾�
    {
        Volume volume = globalVolume.GetComponent<Volume>();
        ColorAdjustments colorAdjustments;
        if (volume.profile.TryGet(out colorAdjustments))
        {
            float targetValue = 1.0f;  // Ŀ��ֵ
            float transitionSpeed = 0.5f;  // �����ٶȣ�������Ҫ����

            float newValue = Mathf.Lerp(colorAdjustments.colorFilter.value.r, targetValue, Time.deltaTime * transitionSpeed);
            colorAdjustments.colorFilter.value = new Color(newValue, newValue, newValue, 1); // ������ɫ�˾���ֵ
        }
    }
}
