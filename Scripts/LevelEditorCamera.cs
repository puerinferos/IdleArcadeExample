using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorCamera : MonoBehaviour
{
    [SerializeField] private float speed = .1f;
    private Vector3 movement;
    private void Update()
    {
        if(!Input.anyKey)
            movement = Vector3.zero;
        if(Input.GetKey(KeyCode.A))
            movement.Set(-1,movement.y,movement.z);
        if(Input.GetKey(KeyCode.W))
            movement.Set(movement.x,movement.y,1);
        if(Input.GetKey(KeyCode.S))
            movement.Set(movement.x,movement.y,-1);
        if(Input.GetKey(KeyCode.D))
            movement.Set(1,movement.y,movement.z);

        transform.position += movement * (speed * Time.deltaTime);
    }
}
