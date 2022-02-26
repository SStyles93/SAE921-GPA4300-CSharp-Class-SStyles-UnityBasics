using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Script References")]
    //private PlayerInput playerInput;
    [Tooltip("Link the Scripts corresponding to the name field")]
    [SerializeField] private PlayerInputSystem playerInput;
    [SerializeField] private PlayerInput_SO playerInputSO;

    [SerializeField] private Transform barel;
    [SerializeField] private float bulletSpeed = 2000f;
    [SerializeField] private GameObject bullet;
    private GameObject currentBullet;

    void Update()
    {
        if (playerInputSO.fire)
        {
            currentBullet = Instantiate(bullet, 
                barel.position,
                barel.rotation);
            playerInputSO.fire = false;
        }
        
    }
    private void FixedUpdate()
    {
        //Add a force to the currentBullet's RB
        if(currentBullet != null)
        {
            currentBullet.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * bulletSpeed * Time.deltaTime, ForceMode.Impulse);
        }       
    }
}
