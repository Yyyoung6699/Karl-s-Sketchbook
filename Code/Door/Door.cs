using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Highlighters;
using System;
using UnityEngine.VFX;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Door : MonoBehaviour
{
    public bool CanOpen;
    private Interaction interaction;
    private UI ui;
    //private Highlighter highlighter;//������ʾ
    //private float OutlineNum = 0.0f;
    //private bool increasing = true; // ����׷�ٹ��ɷ���  
    public GameObject grayKnob;
    public GameObject globalVolume;
    public GameObject Rain;
    public bool Raining;
    void Start()
    {        
        var visualEffect = Rain.GetComponent<VisualEffect>();
        visualEffect.Stop();//����ֹͣ���꣬�ȹ��˵�һ�ش���������
        Raining = false;

        CanOpen = true;
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();

        //if (!highlighter)//������ʾ
        //{
        //    highlighter = GetComponent<Highlighter>();
        //}
    }

    void Update()
    {
        if (interaction.StartDoor == true && CanOpen == true)
        {
            grayKnob.SetActive(true);
            //Outline();//������ʾ��ʱȡ��
            if (interaction.HitInteractionDoor == true)
            {
                //ui.Show_UI_Interact();
                if (Input.GetKey(KeyCode.F))
                {
                    playAnimation();//���Ŷ���
                    //ui.Hide_UI_Interact();//��ʾF��UI
                    Raining = true;//bool��ʼ����������
                }
            }
            //else
            //{
            //    ui.Hide_UI_Interact();//����ʾUI
            //}
        }

        if (Raining == true)
        {
            ChangeVolume();
        }
    }

    //public void Outline()
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

    public void playAnimation()
    {
        gameObject.GetComponent<Animator>().SetTrigger("Open");
        CanOpen = false;
    }

    public void ChangeVolume()
    {
        var visualEffect = Rain.GetComponent<VisualEffect>();
        visualEffect.Play();//ֹͣ����

        Volume volume = globalVolume.GetComponent<Volume>();
        ColorAdjustments colorAdjustments;
        if (volume.profile.TryGet(out colorAdjustments))
        {
            float transitionSpeed = 0.5f;  // �����ٶȣ�������Ҫ����

            float targetR = 167f / 255f;
            float targetG = 167f / 255f;
            float targetB = 200f / 255f;

            float newR = Mathf.Lerp(colorAdjustments.colorFilter.value.r, targetR, Time.deltaTime * transitionSpeed);
            float newG = Mathf.Lerp(colorAdjustments.colorFilter.value.g, targetG, Time.deltaTime * transitionSpeed);
            float newB = Mathf.Lerp(colorAdjustments.colorFilter.value.b, targetB, Time.deltaTime * transitionSpeed);

            colorAdjustments.colorFilter.value = new Color(newR, newG, newB, 1);
        }
    }
}
