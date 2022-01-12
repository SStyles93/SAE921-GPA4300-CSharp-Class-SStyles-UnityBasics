using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float axisSensivity = 0.05f;
    [SerializeField] private Vector3 movement;

    #region Getter/Setter

    public Vector3 Movement
    {
        get{ return movement; }
        set { movement = value; }
    }

    #endregion

    void Update()
    {

        if (Input.GetAxis("Vertical") > axisSensivity)
        {
            movement.z = 1.0f;
        }
        if (Input.GetAxis("Vertical") < -axisSensivity)
        {
            movement.z = -1.0f;
        }
        else if (Input.GetAxis("Vertical") < axisSensivity && Input.GetAxis("Vertical") > -axisSensivity)
        {
            movement.z = 0.0f;
        }

        if (Input.GetAxis("Horizontal") > axisSensivity)
        {
            movement.x = 1.0f;
        }
        if (Input.GetAxis("Horizontal") < -axisSensivity)
        {
            movement.x = -1.0f;
        }
        else if (Input.GetAxis("Horizontal") < axisSensivity && Input.GetAxis("Horizontal") > -axisSensivity)
        {
            movement.x = 0.0f;
        }



    }
}
