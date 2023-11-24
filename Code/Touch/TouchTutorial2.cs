using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTutorial2 : MonoBehaviour
{
    private Subtitle subtitle;

    void Start()
    {
        subtitle = GameObject.Find("Canvas").GetComponent<Subtitle>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            subtitle.StartTutorial7 = true;
        }
    }
}
