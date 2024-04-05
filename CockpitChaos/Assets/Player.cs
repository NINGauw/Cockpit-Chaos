using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 4f;
    [Tooltip("In ms^-1")][SerializeField] float ySpeed = 4f;
    [Tooltip("In m")][SerializeField] float xRange = 20f;
    [Tooltip("In m")][SerializeField] float yRange = 13f;
    void Start()
    {
        
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        MoveHorizontal();
        MoveVertical();
    }

    private void MoveVertical()
    {
        float yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampYPos = Mathf.Clamp(rawYPos, -yRange, yRange - 5);
        transform.localPosition = new Vector3(transform.localPosition.x, clampYPos, transform.localPosition.z);
    }

    private void MoveHorizontal()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        //localPosition là vị trí so với phần tử cha
        transform.localPosition = new Vector3(clampXPos, transform.localPosition.y, transform.localPosition.z);
    }
}
