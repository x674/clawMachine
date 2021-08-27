using System;
using UnityEngine;

public class HookCollisionReceiver : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Detect collision");
    }
}