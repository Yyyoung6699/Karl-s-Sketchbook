using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public bool TouchWaterBool = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            TouchWaterBool = true;
        }
        else
        {
            TouchWaterBool = false;
        }
    }
}
