using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Huaban : MonoBehaviour
{
    private Interaction interaction;
    private Subtitle subtitle;
    public GameObject paint;
    public GameObject frame;
    public GameObject player;
    public GameObject rockWall;
    // Start is called before the first frame update
    void Start()
    {
        subtitle = GameObject.Find("Canvas").GetComponent<Subtitle>();
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.StartHuaban == true)
        {
            Showpaint();
        }
    }

    public void Showpaint()
    {
        subtitle.StartTutorial5 = true;
        paint.SetActive(true);
        DetectPosition();
    }

    public void DetectPosition()
    {
        Transform playertransform = player.transform;
        float px = playertransform.position.x;
        float pz = playertransform.position.z;
        if ((px >= 2.45f && px <= 3.6f) && (pz >= -34f && pz <= -31.5f))
        {
            if(interaction.HitDetectObj == true)
            {
                paint.SetActive(false);
                frame.SetActive(false);
                gameObject.SetActive(false);
                rockWall.SetActive(false);
            }
        }
    }
}
