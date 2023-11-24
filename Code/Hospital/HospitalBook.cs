using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HospitalBook : MonoBehaviour
{
    public bool Over = false;
    private Interaction interaction;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
    }
    // Update is called once per frame
    void Update()
    {
        if (interaction.HitInteractionBook == true)
        {
            Over = true;
            //if (Input.GetKey(KeyCode.F))
            //{
            //    Over = true;
            //}
        }
    }
}
