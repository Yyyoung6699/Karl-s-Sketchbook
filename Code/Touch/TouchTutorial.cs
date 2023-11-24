using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTutorial : MonoBehaviour
{
    private Subtitle subtitle;
    void Start()
    {
        subtitle = GameObject.Find("Canvas").GetComponent<Subtitle>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            subtitle.StartTutorial6 = true;
        }
    }
}
