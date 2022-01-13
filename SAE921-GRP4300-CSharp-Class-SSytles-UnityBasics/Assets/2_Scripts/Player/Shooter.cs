using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Script References")]
    //private PlayerInput playerInput;
    [Tooltip("Link the Scripts corresponding to the name field")]
    [SerializeField] private PlayerInputSystem playerInput;

    [SerializeField] private Transform barel;
    [SerializeField] private float bulletSpeed = 2000f;
    [SerializeField] private GameObject bullet;
    private GameObject currentBullet;

    [SerializeField] float range = 100.0f;

    void Update()
    {
        if (playerInput.fire)
        {
            ProcessRayCast();
            currentBullet = Instantiate(bullet, 
                barel.position,
                barel.rotation);
            playerInput.fire = false;
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
    //Raycastst the bullet trajectory (Instantly... :( )
    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(barel.transform.position, barel.transform.forward, out hit, range))
        {

            //TODO: add some hit effect
            Mob target = hit.transform.GetComponent<Mob>();
            if (target == null)
            {
                return;
            }

            target.TakeDamage(10);
            
        }
        else
        {
            return;
        }
    }
}
