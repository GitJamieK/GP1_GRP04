using System;
using UnityEngine;

public class CameraMoveTrigger : MonoBehaviour
{
    [SerializeField] private CameraMove cam;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController player))
        {
            cam.StartRotateAround();   
        }
    }
}
