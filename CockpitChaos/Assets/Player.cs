using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    private float xThrow, yThrow;
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 70f;
    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 70f;
    [Tooltip("In m")][SerializeField] float xRange = 28f;
    [Tooltip("In m")][SerializeField] float yRange = 21f;

    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float controlPitchFactor = -7f;

    [SerializeField] float positionYawFactor = 1f;
    [SerializeField] float controlYawFactor = 7f;

    [SerializeField] float controlRollFactor = -20f;
    void Start()
    {
        
    }
    void Update()
    {
        Movement();
        Rotation();
    }

    private void Rotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor + xThrow * controlYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void Movement()
    {
        MoveHorizontal();
        MoveVertical();
    }

    private void MoveVertical()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange - 5);
        transform.localPosition = new Vector3(transform.localPosition.x, clampYPos, transform.localPosition.z);
    }

    private void MoveHorizontal()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        //localPosition là vị trí so với phần tử cha
        transform.localPosition = new Vector3(clampXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
