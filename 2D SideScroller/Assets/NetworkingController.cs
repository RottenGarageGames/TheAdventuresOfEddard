using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkingController : MonoBehaviour
{

    public KeyCode UIButton;
    public Canvas UICanvas;
    public bool active;

    void Start()
    {
        active = false;
        UICanvas.enabled = active;
    }
    void Update()
    {
        if (Input.GetKeyDown(UIButton))
        {
            active = !active;
            UICanvas.enabled = active;
        }
    }
}
