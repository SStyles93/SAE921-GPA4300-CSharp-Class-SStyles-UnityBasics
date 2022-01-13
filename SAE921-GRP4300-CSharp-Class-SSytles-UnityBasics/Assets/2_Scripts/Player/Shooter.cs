using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform barel;
    [SerializeField] private float bulletSpeed = 200000f;
    [SerializeField] private GameObject bullet;
    private GameObject currentBullet;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentBullet = Instantiate(bullet, 
                barel.position,
                barel.rotation);
            
        }
        
    }
    private void FixedUpdate()
    {
        if(currentBullet != null)
        {
            currentBullet.GetComponent<Rigidbody>().AddForce(barel.forward * bulletSpeed * Time.deltaTime);
        }
        
    }
}
