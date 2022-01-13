using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private List<GameObject> drops;

    [SerializeField] private float health = 100.0f;

    public List<GameObject> Drops
    {
        get { return drops; }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0.0f)
        {
            Kill();
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.tag == "Bullet")
    //    {
    //        health -= 10.0f;
    //    }
    //}
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void Kill()
    {
        SpawnLoot();
        Destroy(gameObject);
    }
    public void SpawnLoot()
    {
        foreach (GameObject drop in drops)
        {
            Vector3 dropPos = new Vector3(gameObject.transform.position.x + Random.Range(-1.0f, 1.0f),
                 gameObject.transform.position.y,
                 gameObject.transform.position.z + Random.Range(-1.0f, 1.0f));
            Instantiate(drop, dropPos, drop.transform.rotation);
        }
    }
}
