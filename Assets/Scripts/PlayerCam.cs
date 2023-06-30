using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public float sensX;
    public float sensY;


    public Transform orientation;

    public float XRotation;
    public float YRotation;



    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

        YRotation += mouseX;

        XRotation -= mouseY;

        XRotation = Mathf.Clamp(mouseX, -90f, 90f);

        transform.rotation = Quaternion.Euler(XRotation, YRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, YRotation, 0f);
    }
}
