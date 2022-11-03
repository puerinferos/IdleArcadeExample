using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform objToFollow;
    [SerializeField] private float smoothSpeed = .0125f;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 newPos;

    private float distance = 8;

    private Vector3 radialOffset;

    private float timeCounter = 0;
    private void Start()
    {
        offset = transform.position - objToFollow.position;
    }

    private void LateUpdate()
    {
        Rotate();
        newPos = objToFollow.position + offset + radialOffset;
        transform.position = Vector3.Lerp(transform.position,newPos, smoothSpeed);
    }

    private void Rotate()
    {
        timeCounter += Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
        {
            radialOffset += new Vector3(Mathf.Cos(timeCounter),0,Mathf.Sin(timeCounter));
        }
        if (Input.GetKey(KeyCode.D))
        {
            radialOffset -= new Vector3(Mathf.Cos(timeCounter),0,Mathf.Sin(timeCounter));
        }
    }
}
