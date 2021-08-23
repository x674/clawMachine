using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    
    public GameObject Hook,VerticalTube;
    public Animator ClawAnimator ;
    [Header("Vertical Distance")] 
    public float VerticalStartDistance = -0.9833001f;
    public float VerticalEndDistance = -1.723299f;
    [Header("Horizontal Distance")] 
    public float HorizontalStartDistance = -0.9403905f;
    public float HorizontalEndDistance = 0.8929412f;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (VerticalTube.transform.localPosition.x>VerticalEndDistance)
            {
                VerticalTube.transform.Translate(Vector3.back * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (Hook.transform.localPosition.y > HorizontalStartDistance)
            {
                Hook.transform.Translate(Vector3.back * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (VerticalTube.transform.localPosition.x<VerticalStartDistance)
            {
                VerticalTube.transform.Translate(Vector3.forward * Time.deltaTime);
            }
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Hook.transform.localPosition.y < HorizontalEndDistance)
            {
                Hook.transform.Translate(Vector3.forward * Time.deltaTime);
            }
            
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Drop hook");
        }
        
    }
}
