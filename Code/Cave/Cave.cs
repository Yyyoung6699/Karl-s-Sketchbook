using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cave : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Wall1;
    private Interaction interaction;
    // Start is called before the first frame update
    void Start()
    {
        interaction = GameObject.Find("IntManager").GetComponent<Interaction>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interaction.StartCave == true)
        {
            Wall.SetActive(false);
            Wall1.SetActive(true);
        }
    }
}
