using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Object to Spawn")]
    [Tooltip("Drag the object to spawn")]
    [SerializeField] private Mob prefab;
    [Tooltip("Amount of object to spawn")]
    [SerializeField] private int amount;

    [Header("Object \"Tracking\"")]
    [SerializeField] private List<Mob> mobs;
    [SerializeField] private List<Transform> spawnPositions;

    private WaypointManager waypointManager;

    private void Awake()
    {
        waypointManager = GetComponent<WaypointManager>();
    }
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {

            //coins.Add(Instantiate(
            //    coinPrefab,
            //    spawnPositions[Random.Range(0, spawnPositions.Count - 1)].position,
            //    coinPrefab.transform.rotation));
            mobs.Add(Instantiate(
                prefab,
                spawnPositions[i].position,
                prefab.transform.rotation));
            mobs[i].WaypointManager = waypointManager;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < mobs.Count; i++)
        {
            if(mobs[i] == null)
            {
                mobs.RemoveAt(i);
            }
        }
    }
}
