using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [Tooltip("Sets the distance of the raycast")]
    [SerializeField] private float rayRange = 2.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessRayCast();
    }
    void ProcessRayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayRange))
        {
            Mob target = hit.transform.GetComponent<Mob>();
            if(target == null)
            {
                return;
            }
            target.TakeDamage(10.0f);
            Destroy(gameObject);
        }
        //Debug.DrawRay(transform.position, transform.forward * rayRange, Color.green);

    }
}
