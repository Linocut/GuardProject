using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 50f;
    public Transform playerBody;

    private bool withController = false ; 

    float xRotation = 0f;
    

    // Start is called before the first frame update
   
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetJoystickNames().Length >= 1)
        {
            if (Input.GetJoystickNames()[0] == "Controller (Xbox One For Windows)")
            {
                withController = true;
            }
        }

        else
        {
            withController = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        if (withController == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = (Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime);
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);



            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }

        if (withController == true) {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = (Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime);
            xRotation = mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);



            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }


    }
        

}
