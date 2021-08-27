using System;
using System.Collections;
using UnityEngine;

public class ClawController : MonoBehaviour
{
    public GameObject HookMounting, Hook,VerticalTube,Stick;
    [Header("Vertical Distance")] 
    public float VerticalStartDistance = -0.9833001f;
    public float VerticalEndDistance = -1.723299f;
    [Header("Horizontal Distance")] 
    public float HorizontalStartDistance = -0.9403905f;
    public float HorizontalEndDistance = 0.8929412f;

    [Tooltip("In millisecond")]
    [Range(0.0001f, 0.5f)] public float StickTimeAnimation = 0.07f;
    [Range(0.0001f, 0.1f)] public float MoveSpeed = 0.007f;
    [Range(0.14f, 0.8f)] public float MaximumHookDive = 0.8f;
    private Action ONKeyDown => StopAllCoroutines;

    private bool IsAreKeysDown =>
        Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ||
        Input.GetKey(KeyCode.D);

    private IEnumerator Rotate()
    {
        while (Stick.transform.rotation.eulerAngles != Vector3.zero)
        {
            Stick.transform.rotation = Quaternion.Slerp(Stick.transform.rotation,Quaternion.Euler(Vector3.zero),StickTimeAnimation);
        }
        yield return null;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter");
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("OnCollisionStay");
    }

    private IEnumerator HookDive()
    {
        while (HookMounting.transform.localScale.y<MaximumHookDive)
        {
            var localScale = HookMounting.transform.localScale;
            localScale = new Vector3(localScale.x,localScale.y+MoveSpeed,localScale.z);
            HookMounting.transform.localScale = localScale;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return null;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            ONKeyDown.Invoke();
            Stick.transform.rotation = Quaternion.Slerp(Stick.transform.rotation,Quaternion.AngleAxis(45,Vector3.forward),StickTimeAnimation);
            if (VerticalTube.transform.localPosition.x>VerticalEndDistance)
            {
                VerticalTube.transform.Translate(Vector3.back * MoveSpeed);
            }
        }

        if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) ||
            Input.GetKeyUp(KeyCode.D)) && !IsAreKeysDown)
        {
            StartCoroutine(Rotate());
        }

        if (Input.GetKey(KeyCode.A))
        {
            ONKeyDown.Invoke();
            Stick.transform.rotation = Quaternion.Slerp(Stick.transform.rotation,Quaternion.AngleAxis(45,Vector3.left),StickTimeAnimation);
            if (Hook.transform.localPosition.y > HorizontalStartDistance)
            {
                Hook.transform.Translate(Vector3.back * MoveSpeed);
            }
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            ONKeyDown.Invoke();
            Stick.transform.rotation = Quaternion.Slerp(Stick.transform.rotation,Quaternion.AngleAxis(45,Vector3.back),StickTimeAnimation);
            if (VerticalTube.transform.localPosition.x<VerticalStartDistance)
            {
                VerticalTube.transform.Translate(Vector3.forward * MoveSpeed);
            }
            
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            ONKeyDown.Invoke();
            Stick.transform.rotation = Quaternion.Slerp(Stick.transform.rotation,Quaternion.AngleAxis(45,Vector3.right),StickTimeAnimation);
            if (Hook.transform.localPosition.y < HorizontalEndDistance)
            {
                Hook.transform.Translate(Vector3.forward * MoveSpeed);
            }
            
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(HookDive());
        }
        
    }
}
