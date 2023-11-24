using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouse : MonoBehaviour
{
    void Start()
    {
        // Òþ²ØÊó±ê
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
