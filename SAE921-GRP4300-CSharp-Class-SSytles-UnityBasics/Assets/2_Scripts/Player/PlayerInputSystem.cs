using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    [Tooltip("\"Vector2\" from User input, used for movement")]
    [SerializeField] public Vector3 movement;
    [SerializeField] public Vector3 rotation;
    [SerializeField] public bool fire;
    [SerializeField] public bool jump;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputValue value)
    {
        movement.x = value.Get<Vector2>().x;
        movement.z = value.Get<Vector2>().y;
    }
    public void OnRotate(InputValue value)
    {
        rotation.y = value.Get<Vector2>().x;
    }
    public void OnFire(InputValue value)
    {
        fire = true;
    }
    public void OnJump(InputValue input)
    {
        jump = true;
    }
}
