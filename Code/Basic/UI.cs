using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject UI_Interact;
    public GameObject UI_Preview;
    public GameObject UI_NoBook;
    public GameObject UI_HaveBook;
    public GameObject UI_Movement;
    public GameObject UI_Point;

    public float alpha = 0.0f;
    // Start is called before the first frame update
    public void Show_UI_Interact()
    {
        UI_Interact.SetActive(true);
        Hide_UI_Preview();
        Hide_UI_NoBook();
        Hide_UI_HaveBook();
    }
    public void Hide_UI_Interact()
    {
        UI_Interact.SetActive(false);
    }
    public void Show_UI_Preview()
    {
        UI_Preview.SetActive(true);
    }
    public void Hide_UI_Preview()
    {
        UI_Preview.SetActive(false);
    }
    public void Show_UI_NoBook()
    {
        UI_NoBook.SetActive(true);
    }
    public void Hide_UI_NoBook()
    {
        UI_NoBook.SetActive(false);
    }
    public void Show_UI_HaveBook()
    {
        UI_HaveBook.SetActive(true);
    }
    public void Hide_UI_HaveBook()
    {
        UI_HaveBook.SetActive(false);
    }
    public void Show_UI_Movement()
    {
        UI_Movement.SetActive(true);
    }
    public void Hide_UI_Movement()
    {
        UI_Movement.SetActive(false);
    }
    public void Show_UI_Point()
    {
        alpha = Mathf.Lerp(alpha, 1.0f, Time.deltaTime * 5);
        Color startColor = UI_Point.GetComponent<Image>().color; 
        UI_Point.GetComponent<Image>().color = new Color(startColor.r, startColor.g, startColor.b, alpha);
    }
    public void Hide_UI_Point()
    {
        alpha = Mathf.Lerp(alpha, 0.0f, Time.deltaTime * 5);
        Color startColor = UI_Point.GetComponent<Image>().color;
        UI_Point.GetComponent<Image>().color = new Color(startColor.r, startColor.g, startColor.b, alpha);
    }
}
