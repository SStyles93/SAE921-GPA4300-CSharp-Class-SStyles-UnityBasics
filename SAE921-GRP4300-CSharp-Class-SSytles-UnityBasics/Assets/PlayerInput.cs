using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float axisSensivity = 0.05f;
    [SerializeField] private Vector3 newPos;

    #region Getter/Setter

    public Vector3 NewPos
    {
        get{ return newPos; }
        set { newPos = value; }
    }

    #endregion

    void Update()
    {

        if (Input.GetAxis("Vertical") > axisSensivity)
        {
            newPos.z = 1.0f;
        }
        if (Input.GetAxis("Vertical") < -axisSensivity)
        {
            newPos.z = -1.0f;
        }
        else if (Input.GetAxis("Vertical") < axisSensivity && Input.GetAxis("Vertical") > -axisSensivity)
        {
            newPos.z = 0.0f;
        }

        if (Input.GetAxis("Horizontal") > axisSensivity)
        {
            newPos.x = 1.0f;
        }
        if (Input.GetAxis("Horizontal") < -axisSensivity)
        {
            newPos.x = -1.0f;
        }
        else if (Input.GetAxis("Horizontal") < axisSensivity && Input.GetAxis("Horizontal") > -axisSensivity)
        {
            newPos.x = 0.0f;
        }



    }
}
