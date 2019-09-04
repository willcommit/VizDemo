using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField]
    private float speedH = 2.0f;
    private float yaw = 0.0f;
    private int arrayPos;

    bool rotationTrue;
     

    // Start is called before the first frame update
    void Start()
    {
        rotationTrue = false;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetMouseButtonDown(1))
        {
            Cursor.visible = false;
            rotationTrue = true;
        }

        if(Input.GetMouseButtonUp(1))
        {
            yaw = 0.0f;
            Cursor.visible = true;
            rotationTrue = false;   
        }

        if (rotationTrue)
        {
            CalculateMovment();
        }

        
    }

    void CalculateMovment() 
    {
        yaw += speedH * Input.GetAxis("Mouse X");

        transform.Rotate(0.0f, 0.0f, yaw);
    }

    public void SetSideView()
    {
        transform.Rotate(0,0,45);
    }
}
