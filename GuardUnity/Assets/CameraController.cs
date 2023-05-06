using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    public bool check = true;

    float xRotation = 0f;
    string[] joystick;
    

    // Start is called before the first frame update
    void Start()
    {
        joystick = Input.GetJoystickNames();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        if(joystick[0].Length <= 0){
            float mouseX = Input.GetAxis("Mouse X")  *mouseSensitivity * Time.deltaTime;
            float mouseY = (Input.GetAxis("Mouse Y")  *mouseSensitivity * Time.deltaTime);
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            check = false;


            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }
        
        else if(joystick[0].Length > 0){
            float mouseX = Input.GetAxis("Mouse X")  *mouseSensitivity * Time.deltaTime;
            float mouseY = -(Input.GetAxis("Mouse Y")  *mouseSensitivity * Time.deltaTime);
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);


            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
            check = false;

        }

        if (check == true)
        {
            float mouseX = Input.GetAxis("Mouse X")  *mouseSensitivity * Time.deltaTime;
            float mouseY = (Input.GetAxis("Mouse Y")  *mouseSensitivity * Time.deltaTime);
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);


            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            playerBody.Rotate(Vector3.up * mouseX);
        }       
        


        
    }
}
