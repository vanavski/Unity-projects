﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    
    public float speed = 6f;
    public float gravity = -9.8f;

    [Header("Test")]
    public GameObject _object_with_interact;

    private CharacterController _charController;


    void Start()
    {
        _object_with_interact = null;
        _charController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        // PLAYER MOVEMENT
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement.y = gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);

        
            //Application.LoadLevel(0);
    }

    

    public void InteractWithObject(GameObject obj)
    {
        _object_with_interact = obj;
    }
}
