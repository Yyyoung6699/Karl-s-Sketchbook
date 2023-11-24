using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Subtitle : MonoBehaviour
{
    public TextMeshProUGUI subtitleText;
    public TextMeshProUGUI subtitleText2;
    public TextMeshProUGUI subtitleText3;
    public TextMeshProUGUI subtitleText4;
    public TextMeshProUGUI subtitleText5;
    public TextMeshProUGUI subtitleText6;
    public TextMeshProUGUI subtitleText7;
    public TextMeshProUGUI subtitleText8;
    public GameObject backGround;
    public string[] subtitles;
    public string[] subtitles2;
    public string[] subtitles3;
    public string[] subtitles4;
    public string[] subtitles5;
    public string[] subtitles6;
    public string[] subtitles7;
    public string[] subtitles8;
    public float displayDuration = 3.0f;
    public GameObject NoBook;

    private int currentIndex = 0;
    private int currentIndex2 = 0;
    private int currentIndex3 = 0;
    private int currentIndex4 = 0;
    private int currentIndex5 = 0;
    private int currentIndex6 = 0;
    private int currentIndex7 = 0;
    private int currentIndex8 = 0;
    private float timer = 0.0f;
    private float timer2 = 0.0f;
    private float timer3 = 0.0f;
    private float timer4 = 0.0f;
    private float timer5 = 0.0f;
    private float timer6 = 0.0f;
    private float timer7 = 0.0f;
    private float timer8 = 0.0f;
    public bool StartTutorial2;
    public bool StartTutorial3;
    public bool StartTutorial4;
    public bool StartTutorial5;
    public bool StartTutorial6;
    public bool StartTutorial7;
    public bool StartTutorial8;
    void Start()
    {
        StartTutorial2 = false;
        StartTutorial3 = false;
        StartTutorial4 = false;
        StartTutorial5 = false;
        StartTutorial6 = false;
        StartTutorial7 = false;
        StartTutorial8 = false;
        subtitleText.text = "";
        subtitleText2.text = "";
        subtitleText3.text = "";
        subtitleText4.text = "";
        subtitleText5.text = "";
        subtitleText6.text = "";
        subtitleText7.text = "";
        subtitleText8.text = "";
    }

    void Update()
    {
        Tutorial1();

        if (StartTutorial2)
        {
            Tutorial2();
        }
        if (StartTutorial3)
        {
            Tutorial3();
        }
        if (StartTutorial4)
        {
            Tutorial4();
        }
        if (StartTutorial5)
        {
            Tutorial5();
        }
        if (StartTutorial6)
        {
            Tutorial6();
        }
        if (StartTutorial7)
        {
            Tutorial7();
        }
        if (StartTutorial8)
        {
            Tutorial8();
        }
    }
    public void Tutorial1()
    {
        timer += Time.deltaTime;

        if (currentIndex < subtitles.Length)
        {
            if (timer >= displayDuration)
            {
                backGround.SetActive(true);
                subtitleText.text = subtitles[currentIndex];
                currentIndex++;
                timer = 0.0f;
            }
        }
        if (currentIndex == subtitles.Length)
        {
            backGround.SetActive(false);
            NoBook.SetActive(true);
            currentIndex = currentIndex + 1;
        }
    }

    public void Tutorial2()
    {
        timer2 += Time.deltaTime;

        if (currentIndex2 < subtitles2.Length)
        {
            if (timer2 >= displayDuration)
            {
                backGround.SetActive(true);
                subtitleText2.text = subtitles2[currentIndex2];
                currentIndex2++;
                timer2 = 0.0f;
            }
        }
        if (currentIndex2 == subtitles2.Length)
        {
            backGround.SetActive(false);
            currentIndex2 = currentIndex2 + 1;
        }
    }

    public void Tutorial3()
    {
        timer3 += Time.deltaTime;

        if (currentIndex3 < subtitles3.Length)
        {
            if (timer3 >= displayDuration)
            {
                backGround.SetActive(true);
                subtitleText3.text = subtitles3[currentIndex3];
                currentIndex3++;
                timer3 = 0.0f;
            }
        }
        if (currentIndex3 == subtitles3.Length)
        {
            backGround.SetActive(false);
            currentIndex3 = currentIndex3 + 1;
        }
    }

    public void Tutorial4()
    {
        timer4 += Time.deltaTime;

        if (currentIndex4 < subtitles4.Length)
        {
            if (timer4 >= displayDuration)
            {
                backGround.SetActive(true);
                subtitleText4.text = subtitles4[currentIndex4];
                currentIndex4++;
                timer4 = 0.0f;
            }
        }
        if (currentIndex4 == subtitles4.Length)
        {
            backGround.SetActive(false);
            currentIndex4 = currentIndex4 + 1;
        }
    }

    public void Tutorial5()
    {
        timer5 += Time.deltaTime;

        if (currentIndex5 < subtitles5.Length)
        {
            if (timer5 >= displayDuration)
            {
                backGround.SetActive(true);
                subtitleText5.text = subtitles5[currentIndex5];
                currentIndex5++;
                timer5 = 0.0f;
            }
        }
        if (currentIndex5 == subtitles5.Length)
        {
            backGround.SetActive(false);
            currentIndex5 = currentIndex5 + 1;
        }
    }

    public void Tutorial6()
    {
        timer6 += Time.deltaTime;

        if (currentIndex6 < subtitles6.Length)
        {
            if (timer6 >= displayDuration)
            {
                backGround.SetActive(true);
                subtitleText6.text = subtitles6[currentIndex6];
                currentIndex6++;
                timer6 = 0.0f;
            }
        }
        if (currentIndex6 == subtitles6.Length)
        {
            backGround.SetActive(false);
            currentIndex6 = currentIndex6 + 1;
        }
    }

    public void Tutorial7()
    {
        timer7 += Time.deltaTime;

        if (currentIndex7 < subtitles7.Length)
        {
            if (timer7 >= displayDuration)
            {
                backGround.SetActive(true);
                subtitleText7.text = subtitles7[currentIndex7];
                currentIndex7++;
                timer7 = 0.0f;
            }
        }
        if (currentIndex7 == subtitles7.Length)
        {
            backGround.SetActive(false);
            currentIndex7 = currentIndex7 + 1;
        }
    }

    public void Tutorial8()
    {
        timer8 += Time.deltaTime;

        if (currentIndex8 < subtitles8.Length)
        {
            if (timer8 >= displayDuration)
            {
                backGround.SetActive(true);
                subtitleText8.text = subtitles8[currentIndex8];
                currentIndex8++;
                timer8 = 0.0f;
            }
        }
        if (currentIndex8 == subtitles8.Length)
        {
            backGround.SetActive(false);
            currentIndex8 = currentIndex8 + 1;
        }
    }
}
