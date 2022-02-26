using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    ////Default version
    //[Tooltip("\"Vector2\" from User input, used for movement")]
    //[SerializeField] public Vector3 movement;
    //[SerializeField] public Vector3 rotation;
    //[SerializeField] public bool fire;
    //[SerializeField] public bool jump;

    //SO version
    [SerializeField] private PlayerInput_SO playerInputSO;


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
        ////Default version
        //movement.x = value.Get<Vector2>().x;
        //movement.z = value.Get<Vector2>().y;

        //SO version
        playerInputSO.movement.x = value.Get<Vector2>().x;
        playerInputSO.movement.z = value.Get<Vector2>().y;
    }
    public void OnRotate(InputValue value)
    {
        ////Default version
        //rotation.y = value.Get<Vector2>().x;

        //SO version
        playerInputSO.rotation.y = value.Get<Vector2>().x;
    }
    public void OnFire(InputValue value)
    {
        ////Default version
        //fire = true;

        //SO version
        playerInputSO.fire = true;
    }
    public void OnJump(InputValue input)
    {
        ////Default version
        //jump = true;

        //SO version
        playerInputSO.jump = true;
    }
}
