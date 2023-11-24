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
    //private bool increasing = true; // 用于追踪过渡方向
    void Start()
    {
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
        door = GameObject.Find("Door").GetComponent<Door>();
        
        //if (!highlighter)
        //{
        //    highlighter = GetComponent<Highlighter>();
        //}//高亮提示，暂时去掉
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
        visualEffect.Stop();//停止下雨
        door.Raining = false;
        ChangeVolume();//天气变晴
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

            // 在每一帧更新透明度
            alpha = Mathf.Lerp(alpha, 1.0f, Time.deltaTime * 0.5f); // 这将使透明度从0逐渐过渡到1
            if (renderer.material.HasProperty("_TransparentSrength"))
            {
                renderer.material.SetFloat("_TransparentSrength", alpha); // 设置Alpha属性值为0.5
            }
            ziFaGuang = Mathf.Lerp(alpha, 0.5f, Time.deltaTime * 0.5f);
            if (renderer.material.HasProperty("_EmissiveStrength"))
            {
                renderer.material.SetFloat("_EmissiveStrength", ziFaGuang); // 设置Alpha属性值为0.5
            }
            //// 设置新的透明度到材质
            //Color color = material.color;
            //color.a = alpha;
            //material.color = color;
        }
    }

    //public void Outline()////高亮提示，暂时去掉
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

    public void ChangeVolume()//天气滤镜
    {
        Volume volume = globalVolume.GetComponent<Volume>();
        ColorAdjustments colorAdjustments;
        if (volume.profile.TryGet(out colorAdjustments))
        {
            float targetValue = 1.0f;  // 目标值
            float transitionSpeed = 0.5f;  // 过渡速度，根据需要调整

            float newValue = Mathf.Lerp(colorAdjustments.colorFilter.value.r, targetValue, Time.deltaTime * transitionSpeed);
            colorAdjustments.colorFilter.value = new Color(newValue, newValue, newValue, 1); // 设置颜色滤镜的值
        }
    }
}
