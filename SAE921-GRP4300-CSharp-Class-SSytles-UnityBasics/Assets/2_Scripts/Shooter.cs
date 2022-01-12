using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform barel;
    [SerializeField] private float bulletSpeed = 200000f;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject currentBullet;
            currentBullet = Instantiate(bullet, barel.position, barel.rotation);
            currentBullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * bulletSpeed * Time.deltaTime);
        }
    }
}
