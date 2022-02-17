using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private List<GameObject> _drops;

    [SerializeField] private float _health = 100.0f;
    [SerializeField] private float _speed = 1.0f;

    [SerializeField] private float _internalTimer;
    [SerializeField] private float _tickTimer;

    [SerializeField] private Waypoint _currentTarget;
    [SerializeField] private float distanceToSwitchTargets = 0.8f;
    [SerializeField] private Waypoint _previousTarget;

    [SerializeField] private WaypointManager waypointManager;

    public List<GameObject> Drops { get => _drops; private set => _drops = value; }
    public Waypoint Target { get => _currentTarget; set => _currentTarget = value; }
    public WaypointManager WaypointManager { get => waypointManager; set => waypointManager = value; }

    private void Awake()
    {
        
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(_health <= 0.0f)
        {
            Kill();
        }

        _internalTimer += Time.deltaTime;

        if(_internalTimer >= _tickTimer)
        {
            _internalTimer = 0.0f;
            Tick();
        }

        if(_currentTarget != null)
        {
            FollowTarget(_currentTarget);

            if ((_currentTarget.transform.position - transform.position).magnitude <= distanceToSwitchTargets)
            {
                //CallFornew Target
                _previousTarget = _currentTarget;
                _currentTarget = waypointManager.GetNewTarget();
                
            }

        }
        else
        {
            _currentTarget = waypointManager.GetNewTarget();
        }
    }

    void Tick()
    {

    }

    private void FollowTarget(Waypoint waypoint)
    {
        Vector3 direction = (waypoint.transform.position - transform.position).normalized;
        transform.LookAt(waypoint.transform.position);
        transform.position += direction * _speed * Time.deltaTime;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }

    private void Kill()
    {
        SpawnLoot();
        Destroy(gameObject);
    }
    public void SpawnLoot()
    {
        foreach (GameObject drop in Drops)
        {
            Vector3 dropPos = new Vector3(gameObject.transform.position.x + Random.Range(-1.0f, 1.0f),
                 gameObject.transform.position.y,
                 gameObject.transform.position.z + Random.Range(-1.0f, 1.0f));
            Instantiate(drop, dropPos, drop.transform.rotation);
        }
    }
}
