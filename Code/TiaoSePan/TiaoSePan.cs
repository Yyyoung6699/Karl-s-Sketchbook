using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiaoSePan : MonoBehaviour
{
    private Interaction interaction;
    //private int x = 0;
    public GameObject water;
    public GameObject waterFog;
    public GameObject waterWall;
    public Texture[] textureArray;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.StartTiaoSePan != 0)
        {
            switchDetect();
        }
    }

    public void switchDetect()
    {
        int bookTextrue = interaction.StartTiaoSePan;
            if (bookTextrue == 4)
            {
                ChangeTiaoSePan(bookTextrue);
                ChangeWater(bookTextrue);
                //ChangeFog(bookTextrue);
                NoWall();
            }
            else
            {
                ChangeTiaoSePan(bookTextrue);
                ChangeWater(bookTextrue);
                //ChangeFog(bookTextrue);
            }
    }

    public void ChangeTiaoSePan(int bookTextrue)
    {
        if (bookTextrue != 0) 
        {
            Renderer renderer = gameObject.GetComponent<Renderer>();
            Material material = renderer.material;
            material.SetTexture("_BaseMap", textureArray[bookTextrue]);
        }
    }

    public void ChangeWater(int bookTextrue)
    {
        float newRT = 0;
        float newGT = 0;
        float newBT = 0;
        float newTransT = 0;
        switch (bookTextrue)
        {
            case 1:
                newRT = 0.333f;
                newGT = 0.333f;
                newBT = 0.333f;
                newTransT = 0.2f;
                break;
            case 2:
                newRT = 0f;
                newGT = 0f;
                newBT = 0f;
                newTransT = 0.2f;
                break;
            case 3:
                newRT = 0.078f;
                newGT = 0.537f;
                newBT = 0.117f;
                newTransT = 0.2f;
                break;
            case 4:
                newRT = 0.302f;
                newGT = 0.635f;
                newBT = 0.670f;
                newTransT = 3.5f;
                break;
            case 5:
                newRT = 0.333f;
                newGT = 0.333f;
                newBT = 0.333f;
                newTransT = 0.2f;
                break;
        }
        Renderer renderer = water.GetComponent<Renderer>();
        Material material = renderer.material;
        float newR = Mathf.Lerp(material.GetColor("_WaterColor").r, newRT, Time.deltaTime);
        float newG = Mathf.Lerp(material.GetColor("_WaterColor").g, newGT, Time.deltaTime);
        float newB = Mathf.Lerp(material.GetColor("_WaterColor").b, newBT, Time.deltaTime);
        float newTrans = Mathf.Lerp(material.GetFloat("_Transparency"), newTransT, Time.deltaTime);
        Color newColor = new Color(newR, newG, newB, 0); // 设置颜色
        material.SetColor("_WaterColor", newColor);
        material.SetFloat("_Transparency", newTrans);
    }

    public void ChangeFog(int bookTextrue)
    {
        float new1RT = 0;
        float new1GT = 0;
        float new1BT = 0;
        float new2RT = 0;
        float new2GT = 0;
        float new2BT = 0;
        switch (bookTextrue)
        {
            case 1:
                new1RT = 0.333f;
                new1GT = 0.333f;
                new1BT = 0.333f;
                new2RT = 0.333f;
                new2GT = 0.333f;
                new2BT = 0.333f;
                break;
            case 2:
                new1RT = 0f;
                new1GT = 0f;
                new1BT = 0f;
                new2RT = 0f;
                new2GT = 0f;
                new2BT = 0f;
                break;
            case 3:
                new1RT = 0f;
                new1GT = 1f;
                new1BT = 0.196f;
                new2RT = 0f;
                new2GT = 1f;
                new2BT = 0.196f;
                break;
            case 4:
                new1RT = 0.588f;
                new1GT = 0.807f;
                new1BT = 1.000f;
                new2RT = 0.050f;
                new2GT = 0.243f;
                new2BT = 0.556f;
                break;
            case 5:
                new1RT = 0.333f;
                new1GT = 0.333f;
                new1BT = 0.333f;
                new2RT = 0.333f;
                new2GT = 0.333f;
                new2BT = 0.333f;
                break;
        }
        Renderer renderer = waterFog.GetComponent<Renderer>();
        Material material = renderer.material;

        float new1R = Mathf.Lerp(material.GetColor("_BaseColor").r, new1RT, Time.deltaTime);
        float new1G = Mathf.Lerp(material.GetColor("_BaseColor").g, new1GT, Time.deltaTime);
        float new1B = Mathf.Lerp(material.GetColor("_BaseColor").b, new1BT, Time.deltaTime);
        float new1A = 0.784f;
        Color newColor1 = new Color(new1R, new1G, new1B, new1A); // 设置颜色
        float new2R = Mathf.Lerp(material.GetColor("_EmissionColor").r, new2RT, Time.deltaTime);
        float new2G = Mathf.Lerp(material.GetColor("_EmissionColor").g, new2GT, Time.deltaTime);
        float new2B = Mathf.Lerp(material.GetColor("_EmissionColor").b, new2BT, Time.deltaTime);
        Color newColor2 = new Color(new2R, new2G, new2B); // 设置颜色
        material.SetColor("_BaseColor", newColor1);
        material.SetColor("_EmissionColor", newColor2);
    }

    public void NoWall()
    {
        waterWall.SetActive(false);
    }
}
