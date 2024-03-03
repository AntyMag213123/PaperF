using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public float mouseSens = 50f;

    public Transform playerBody;

    float xRotatinon = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotatinon -= mouseY;
        xRotatinon = Mathf.Clamp(xRotatinon, -45f, 45f);

        transform.localRotation = Quaternion.Euler(xRotatinon, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}