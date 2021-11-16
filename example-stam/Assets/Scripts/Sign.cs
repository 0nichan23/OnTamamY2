using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    Camera TheMainCamera;
    void Start()
    {
        TheMainCamera = Camera.main;
    }

    
    void Update()
    {
        this.transform.LookAt(TheMainCamera.transform.position);   
    }
}
