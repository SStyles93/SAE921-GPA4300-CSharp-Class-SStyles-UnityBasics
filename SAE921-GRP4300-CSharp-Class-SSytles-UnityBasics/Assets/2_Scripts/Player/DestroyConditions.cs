using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyConditions : MonoBehaviour
{
    //[SerializeField] private Vector3 newPos;
    [SerializeField] private float delay = 10.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delay -= Time.deltaTime;
        if(delay <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Mob>())
        {
            Destroy(gameObject);
        }
    }
    //private void OnMouseOver()
    //{
    //    if (Input.GetKeyDown(KeyCode.Mouse0))
    //    {
    //        Destroy(gameObject);
    //        newPos = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
    //        Instantiate(gameObject, newPos, Quaternion.identity);
    //    }
    //}
}
