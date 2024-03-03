using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{


    public Transform target;
    public Transform follow0bj;
    public float mouseSensitivity = 3, MouseVSensitivity = 1.5f, minViewAngle = 342, maxViewAngle = 25;

    public bool invertedMouse;
    private bool look = true;


    void Start()
    {
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        Scene SampleScene = SceneManager.GetActiveScene();
        int buildIndex = SampleScene.buildIndex;
        if (buildIndex > 0)
        {
        }
        if (look)
        {
            Look();
        }
        
    }

    private void Look()
    {
        #region Horizontal Camera Movement
        float horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        target.Rotate(0, horizontal, 0);
        #endregion

        #region Vertical Camera Movement
        float vertical = Input.GetAxis("Mouse Y") * mouseSensitivity;

        if (invertedMouse)
        {
            follow0bj.transform.rotation *= Quaternion.AngleAxis(vertical * mouseSensitivity, Vector3.right);
        }
        else if (!invertedMouse)
        {
            follow0bj.transform.rotation *= Quaternion.AngleAxis(-(vertical * mouseSensitivity), Vector3.right);
        }
    

        var angles = follow0bj.transform.localEulerAngles;
        angles.z = 0;

        var angle = follow0bj.transform.localEulerAngles.x;

        //вращение вверх или вниз при зажиме 
        if (angle > 186 && angle < minViewAngle)
        {
            angles.x = minViewAngle;
        }
        else if (angle < 180 && angle > maxViewAngle)
        {
            angles.x = maxViewAngle;
        }

        angles.y = 0;
        follow0bj.transform.localEulerAngles = angles;
        #endregion
    }
}