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
    //private Highlighter highlighter;//高亮提示
    //private float OutlineNum = 0.0f;
    //private bool increasing = true; // 用于追踪过渡方向  
    public GameObject grayKnob;
    public GameObject globalVolume;
    public GameObject Rain;
    public bool Raining;
    void Start()
    {        
        var visualEffect = Rain.GetComponent<VisualEffect>();
        visualEffect.Stop();//开局停止下雨，等过了第一关打开门再下雨
        Raining = false;

        CanOpen = true;
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
        ui = GameObject.Find("Canvas").GetComponent<UI>();

        //if (!highlighter)//高亮提示
        //{
        //    highlighter = GetComponent<Highlighter>();
        //}
    }

    void Update()
    {
        if (interaction.StartDoor == true && CanOpen == true)
        {
            grayKnob.SetActive(true);
            //Outline();//高亮提示暂时取消
            if (interaction.HitInteractionDoor == true)
            {
                //ui.Show_UI_Interact();
                if (Input.GetKey(KeyCode.F))
                {
                    playAnimation();//开门动画
                    //ui.Hide_UI_Interact();//显示F键UI
                    Raining = true;//bool开始下雨且阴天
                }
            }
            //else
            //{
            //    ui.Hide_UI_Interact();//不显示UI
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
    //        OutlineNum = Mathf.Lerp(OutlineNum, 40.0f, Time.deltaTime * 8.0f); // 这将使透明度从0逐渐过渡到40
    //        if (OutlineNum >= 39.9f)
    //        {
    //            increasing = false; // 到达40后改变方向
    //        }
    //    }
    //    else
    //    {
    //        OutlineNum = Mathf.Lerp(OutlineNum, 0.0f, Time.deltaTime * 8.0f); // 这将使透明度从40逐渐过渡回0
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
        visualEffect.Play();//停止下雨

        Volume volume = globalVolume.GetComponent<Volume>();
        ColorAdjustments colorAdjustments;
        if (volume.profile.TryGet(out colorAdjustments))
        {
            float transitionSpeed = 0.5f;  // 过渡速度，根据需要调整

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
